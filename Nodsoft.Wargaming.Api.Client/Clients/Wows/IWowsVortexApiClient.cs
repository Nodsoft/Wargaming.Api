using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Vortex;

namespace Nodsoft.Wargaming.Api.Client.Clients.Wows;

/// <summary>
/// Specifies a client for the World of Warships Vortex API.
/// </summary>
public interface IWowsVortexApiClient
{
	/// <summary>
	/// Fetches account information for a given account ID.
	/// </summary>
	/// <param name="accountId">The account ID to fetch information for.</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>The account information, null if not found.</returns>
	Task<VortexAccountInfo?> FetchAccountAsync(uint accountId, CancellationToken ct = default);
	
	/// <summary>
	/// Fetches account information for given account IDs.
	/// </summary>
	/// <param name="accountIds">The account IDs to fetch information for.</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>A ID-Info keyed dictionary of account information.</returns>
	Task<Dictionary<uint, VortexAccountInfo?>> FetchAccountsAsync(IEnumerable<uint> accountIds, CancellationToken ct = default);
	
	/// <summary>
	/// Fetches an account's clan information for a given account ID.
	/// </summary>
	/// <param name="accountId">The account ID to fetch information for.</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>The clan information, null if not found.</returns>
	Task<VortexAccountClanInfo?> FetchAccountClanAsync(uint accountId, CancellationToken ct = default);
	
	/// <summary>
	/// Fetches account clan information for given account IDs.
	/// </summary>
	/// <param name="accountIds">The account IDs to fetch information for.</param>
	/// <param name="ct">The cancellation token.</param>
	/// <returns>A ID-Info keyed dictionary of account clan information.</returns>
	Task<Dictionary<uint, VortexAccountClanInfo?>> FetchAccountsClansAsync(IEnumerable<uint> accountIds, CancellationToken ct = default);
}