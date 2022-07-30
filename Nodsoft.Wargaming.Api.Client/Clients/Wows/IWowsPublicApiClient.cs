using Nodsoft.Wargaming.Api.Common.Data.Responses;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Public;

namespace Nodsoft.Wargaming.Api.Client.Clients.Wows;

/// <summary>
/// Specifies a client for the World of Warships Public API.
/// </summary>
/// <remarks>
///	This API is throttled, IP-restricted, and requires AppId authentication.
/// </remarks>
public interface IWowsPublicApiClient
{
	/// <summary>
	/// Queries the API for a list of players matching the specified search query.
	/// </summary>
	/// <param name="search">The search query (player's name).</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>A list of players matching the search query.</returns>
	Task<ApiResponse<IEnumerable<AccountListing>>?> ListPlayersAsync(string search, CancellationToken ct = default);
	
	/// <summary>
	/// Fetches account information for the specified account IDs.
	/// </summary>
	/// <param name="accountIds">The account IDs to fetch.</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>A ID-Info keyed dictionary of account information.</returns>
	Task<ApiResponse<Dictionary<uint, AccountInfo>>?> FetchPlayersAsync(IEnumerable<uint> accountIds, CancellationToken ct = default);
	
	/// <summary>
	/// Queries the Public API for a list of clans matching the specified search query.
	/// </summary>
	/// <param name="search">The search query (clan's name).</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>A list of clans matching the search query.</returns>
	Task<ApiResponse<IEnumerable<ClanListing>>?> ListClansAsync(string search, CancellationToken ct = default);
	
	/// <summary>
	/// Fetches clan information for the specified clan IDs.
	/// </summary>
	/// <param name="clanIds">The clan IDs to fetch.</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>A ID-Info keyed dictionary of clan information.</returns>
	Task<ApiResponse<Dictionary<uint, ClanInfo>>?> FetchClansAsync(IEnumerable<uint> clanIds, CancellationToken ct = default);
	
	/// <summary>
	/// Fetches clan membership information for the specified account IDs.
	/// </summary>
	/// <param name="accountIds">The account IDs to fetch.</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>A ID-Info keyed dictionary of clan membership information.</returns>
	Task<ApiResponse<Dictionary<uint, AccountClanInfo>>?> FetchAccountsClanInfoAsync(IEnumerable<uint> accountIds, CancellationToken ct = default);
}