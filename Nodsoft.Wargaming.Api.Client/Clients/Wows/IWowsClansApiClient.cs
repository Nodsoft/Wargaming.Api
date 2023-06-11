using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

namespace Nodsoft.Wargaming.Api.Client.Clients.Wows;

/// <summary>
/// Specifies a client for the World of Warships Clans API.
/// </summary>
public interface IWowsClansApiClient
{
	/// <summary>
	/// Fetches a view of clan information for the specified clan ID.
	/// </summary>
	/// <param name="clanId">The clan ID.</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>A view of clan information, null if not found.</returns>
	Task<ClanView?> FetchClanViewAsync(uint clanId, CancellationToken ct = default);
	
	/// <summary>
	/// Fetches a view of clan members for the specified clan ID, with stats for a specified category.
	/// </summary>
	/// <param name="clanId">The clan ID.</param>
	/// <param name="statsCategory">The player stats category, corresponds to a battle type.</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>A view of clan members, null if not found.</returns>
	Task<ClanMembersView?> FetchClanMembersAsync(uint clanId, BattleType statsCategory = BattleType.Random, CancellationToken ct = default);
	
	/// <summary>
	/// Queries the API for a list of clans matching the specified search query.
	/// </summary>
	/// <param name="search">The search query (matches by clan name or tag).</param>
	/// <param name="limit">The maximum number of results to return.</param>
	/// <param name="statsCategory">The player stats category, corresponds to a battle type.</param>
	/// <param name="offset">The offset from the first result.</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>A list of clan search results, null if not found.</returns>
	Task<ClanSearchResults?> SearchClansAsync(string search, uint limit = 20, BattleType statsCategory = BattleType.Random, uint offset = 0, CancellationToken ct = default);
}