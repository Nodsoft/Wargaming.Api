namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Public;

public class AccountClanInfo
{
	public uint AccountId { get; init; }
	public string AccountName { get; init; } = string.Empty;
	
	public uint? ClanId { get; init; }
	public ClanRole? Role { get; init; }
	
	public ulong? JoinedAt { get; init; }
	public DateTime? JoinedAtTime => JoinedAt is null ? null : DateTime.UnixEpoch.AddSeconds(JoinedAt ?? 0);
}