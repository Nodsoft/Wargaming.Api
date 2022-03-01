using System.Net.Http.Json;
using Microsoft.AspNetCore.WebUtilities;
using Nodsoft.Wargaming.Api.Common.Data.Response;
using Nodsoft.Wargaming.Api.Common.Data.Response.Wows.Public;

namespace Nodsoft.Wargaming.Api.Client.Clients.Wows;

public class WowsPublicApiClient : PublicApiClientBase
{
	public WowsPublicApiClient(HttpClient client, PublicApiOptions options) : base(client, options) { }
	
	
	// Api : account/list/
	public async Task<IEnumerable<AccountListing>?> ListPlayersAsync(string search, CancellationToken ct = default)
	{
		Dictionary<string, string> query = GetDefaultQueryParameters();
		query.Add("search", search);

		using HttpRequestMessage request = new(HttpMethod.Get, QueryHelpers.AddQueryString("account/list/", query));
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		return (await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<AccountListing>>>(SerializerOptions, ct))?.Data;
	}
	
	// Api : account/info/
	public async Task<Dictionary<uint, AccountInfo>?> FetchPlayersAsync(IEnumerable<uint> accountIds, CancellationToken ct = default)
	{
		Dictionary<string, string> query = GetDefaultQueryParameters();
		query.Add("account_id", string.Join(',', accountIds));
		
		using HttpRequestMessage request = new(HttpMethod.Get, QueryHelpers.AddQueryString("account/info/", query));
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		return (await response.Content.ReadFromJsonAsync<ApiResponse<Dictionary<uint, AccountInfo>>>(SerializerOptions, ct))?.Data;
	}
}