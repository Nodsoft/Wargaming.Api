using System.Net.Http.Json;
using Microsoft.AspNetCore.WebUtilities;
using Nodsoft.Wargaming.Api.Client.Infrastructure;
using Nodsoft.Wargaming.Api.Common;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

namespace Nodsoft.Wargaming.Api.Client.Clients.Wows;

public class WowsClansApiClient : ApiClientBase, IWowsClansApiClient
{
	public WowsClansApiClient(HttpClient client) : base(client) { }
	
	public static string GetApiHost(Region region) => region switch
	{
		Region.EU  => "https://clans.worldofwarships.eu/api/",
		Region.NA  => "https://clans.worldofwarships.com/api/",
		Region.CIS => "https://clans.worldofwarships.ru/api/",
		Region.SEA => "https://clans.worldofwarships.asia/api/",
		
		_ => throw new NotImplementedException()
	};
	
	public async Task<ClanView?> FetchClanViewAsync(uint clanId, CancellationToken ct = default) 
	{
		using HttpRequestMessage request = new(HttpMethod.Get, $"clanbase/{clanId}/claninfo/");
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		return response.IsSuccessStatusCode 
			? (await response.Content.ReadFromJsonAsync<ClanViewWrapper>(SerializerOptions, ct))?.Clanview 
			: null;
	}

	public async Task<ClanMembersView?> FetchClanMembersAsync(uint clanId, BattleType statsCategory = BattleType.Random, CancellationToken ct = default)
	{
		_ = statsCategory is BattleType.Clans ? throw new InvalidOperationException("This method cannot return Clans-oriented member stats.") : false;

		using HttpRequestMessage request = new(HttpMethod.Get, $"members/{clanId}/?battle_type={statsCategory.ToClanQueryArgument()}");
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		return response.IsSuccessStatusCode 
			? await response.Content.ReadFromJsonAsync<ClanMembersView>(SerializerOptions, ct) 
			: null;
	}
	
	public async Task<ClanSearchResults?> SearchClansAsync(string search, uint limit = 20, BattleType statsCategory = BattleType.Random, uint offset = 0, CancellationToken ct = default)
	{
		Dictionary<string, string> query = new()
		{
			{ "search", search },
			{ "battle_type", statsCategory.ToClanQueryArgument() },
			{ "limit", limit.ToString() },
			{ "offset", offset.ToString() }
		};

		using HttpRequestMessage request = new(HttpMethod.Get, QueryHelpers.AddQueryString("search/clans/", query));
		
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		return response.IsSuccessStatusCode 
			? await response.Content.ReadFromJsonAsync<ClanSearchResults>(SerializerOptions, ct) 
			: null;
	}
}