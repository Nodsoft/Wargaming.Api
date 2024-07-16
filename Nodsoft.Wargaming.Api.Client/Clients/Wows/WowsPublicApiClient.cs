using System.Net.Http.Json;
using Microsoft.AspNetCore.WebUtilities;
using Nodsoft.Wargaming.Api.Common.Data.Responses;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Public;

namespace Nodsoft.Wargaming.Api.Client.Clients.Wows;

public class WowsPublicApiClient : PublicApiClientBase, IWowsPublicApiClient
{
	public WowsPublicApiClient(HttpClient client, PublicApiOptions options) : base(client, options) { }
	
	
	// Api : account/list/
	public async Task<ApiResponse<IEnumerable<AccountListing>>?> ListPlayersAsync(string search, CancellationToken ct = default)
	{
		Dictionary<string, string> query = GetDefaultQueryParameters();
		query.Add("search", search);

		using HttpRequestMessage request = new(HttpMethod.Get, QueryHelpers.AddQueryString("account/list/", query!));
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		return await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<AccountListing>>>(SerializerOptions, ct);
	}
	
	// Api : account/info/
	public async Task<ApiResponse<Dictionary<uint, AccountInfo>>?> FetchPlayersAsync(IEnumerable<uint> accountIds, CancellationToken ct = default)
	{
		Dictionary<string, string> query = GetDefaultQueryParameters();
		query.Add("account_id", string.Join(',', accountIds));
		
		using HttpRequestMessage request = new(HttpMethod.Get, QueryHelpers.AddQueryString("account/info/", query!));
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		return await response.Content.ReadFromJsonAsync<ApiResponse<Dictionary<uint, AccountInfo>>>(SerializerOptions, ct);
	}
	
	// Api : clans/list/
	public async Task<ApiResponse<IEnumerable<ClanListing>>?> ListClansAsync(string search, CancellationToken ct = default)
	{
		Dictionary<string, string> query = GetDefaultQueryParameters();
		query.Add("search", search);

		using HttpRequestMessage request = new(HttpMethod.Get, QueryHelpers.AddQueryString("clans/list/", query!));
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		return await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<ClanListing>>>(SerializerOptions, ct);
	}
	
	// Api : clans/info/
	public async Task<ApiResponse<Dictionary<uint, ClanInfo>>?> FetchClansAsync(IEnumerable<uint> clanIds, CancellationToken ct = default)
	{
		Dictionary<string, string> query = GetDefaultQueryParameters();
		query.Add("clan_id", string.Join(',', clanIds));
		
		using HttpRequestMessage request = new(HttpMethod.Get, QueryHelpers.AddQueryString("clans/info/", query!));
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		return await response.Content.ReadFromJsonAsync<ApiResponse<Dictionary<uint, ClanInfo>>>(SerializerOptions, ct);
	}
	
	// Api : account/info/
	public async Task<ApiResponse<Dictionary<uint, AccountClanInfo>>?> FetchAccountsClanInfoAsync(IEnumerable<uint> accountIds, CancellationToken ct = default)
	{
		Dictionary<string, string> query = GetDefaultQueryParameters();
		query.Add("account_id", string.Join(',', accountIds));
		
		using HttpRequestMessage request = new(HttpMethod.Get, QueryHelpers.AddQueryString("clans/accountinfo/", query!));
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		return await response.Content.ReadFromJsonAsync<ApiResponse<Dictionary<uint, AccountClanInfo>>>(SerializerOptions, ct);
	}
}