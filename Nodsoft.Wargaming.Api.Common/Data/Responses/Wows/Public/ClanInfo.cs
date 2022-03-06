namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Public;

public record ClanInfo : ClanListing
{
	public uint CreatorId { get; init; }
	public string CreatorName { get; init; } = string.Empty;
	
	public uint LeaderId { get; init; }
	public string LeaderName { get; init; } = string.Empty;
	
	public ulong CreatedAt { get; init; }
	public DateTime CreatedAtTime => DateTime.UnixEpoch.AddSeconds(CreatedAt);
	
	public ulong UpdatedAt { get; init; }
	public DateTime UpdatedAtTime => DateTime.UnixEpoch.AddSeconds(UpdatedAt);
	
	public ulong? RenamedAt { get; init; }
	public DateTime? RenamedAtTime => RenamedAt is null ? null : DateTime.UnixEpoch.AddSeconds(RenamedAt ?? 0);
	
	public string? OldTag { get; init; }
	public string? OldName { get; init; }
	
	public bool IsClanDisbanded { get; init; }
	
	public string Description { get; init; } = string.Empty;

	public List<uint> MembersIds { get; init; } = new();
}