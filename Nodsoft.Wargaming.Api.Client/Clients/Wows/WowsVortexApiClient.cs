using System.Collections.Concurrent;
using System.Net.Http.Json;
using Nodsoft.Wargaming.Api.Common;
using Nodsoft.Wargaming.Api.Common.Data.Response;
using Nodsoft.Wargaming.Api.Common.Data.Response.Wows.Public;

namespace Nodsoft.Wargaming.Api.Client.Clients.Wows;

public class WowsVortexApiClient : ApiClientBase
{
	public WowsVortexApiClient(HttpClient client) : base(client) { }
	
	public static string GetApiHost(Region region) => region switch
	{
		Region.EU	=> "https://vortex.worldofwarships.eu/api/",
		Region.NA	=> "https://vortex.worldofwarships.com/api/",
		Region.CIS	=> "https://vortex.worldofwarships.ru/api/",
		Region.SEA	=> "https://vortex.worldofwarships.asia/api/",
		
		_			=> throw new NotImplementedException()
	};
	
	
	// Api : accounts/{id}
	public async Task<AccountInfo?> FetchAccountAsync(uint accountId, CancellationToken ct = default) 
	{
		using HttpRequestMessage request = new(HttpMethod.Get, $"accounts/{accountId}/");
		using HttpResponseMessage response = await Client.SendAsync(request, ct);

		string responseContent = await response.Content.ReadAsStringAsync(ct);
		
		if (response.IsSuccessStatusCode)
		{
			Dictionary<uint, AccountInfo> parsedRequest = await response.Content.ReadFromJsonAsync<ApiResponse<Dictionary<uint, AccountInfo>>>(SerializerOptions, ct);
			(uint key, AccountInfo? value) = parsedRequest.First();

			return value with { AccountId = key };
		}

		return null;
	}
	
	public async Task<Dictionary<uint, AccountInfo?>> FetchAccountsAsync(IEnumerable<uint> accountIds, CancellationToken ct = default)
	{
		Dictionary<uint, AccountInfo?> accountFetches = new();

		foreach (uint id in accountIds.AsParallel().WithCancellation(ct).WithMergeOptions(ParallelMergeOptions.NotBuffered))
		{
			try
			{
				accountFetches.Add(id, await FetchAccountAsync(id, ct));
			}
			catch
			{
				// ignored
			}
		}

		return accountFetches;
	}
}