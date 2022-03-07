namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanMembersView
{
	public ClanStatistics ClanStatistics { get; init; } = null!;
	public ClanMember[]? Items { get; init; }
	public bool IsHiddenStatistics { get; init; }
	public string Status { get; init; } = string.Empty;
	public DateTimeOffset LastUpdatedAt { get; init; }
}

public record ClanMember : ClanStatistics
{
	public ClanMemberRole Role { get; init; } = null!;
	public bool IsPress { get; init; }
	public bool IsHiddenStatistics { get; init; }
	public ulong LastBattleTime { get; init; }
	public uint? AccumulativeClanResource { get; init; }
	public Uri ProfileLink { get; init; } = null!;
	public bool IsBanned { get; init; }
	public long SeasonId { get; init; }
	public bool? IsBonusActivated { get; init; }
	public long DaysInClan { get; init; }
	public float FragsPerBattle { get; init; }
	public bool AbnormalResults { get; init; }
	public object? SeasonRank { get; init; }
	public long? Leveling { get; init; }
	public bool OnlineStatus { get; init; }
	public uint Id { get; init; }
	public float BattlesPerDay { get; init; }
	public string Name { get; init; } = string.Empty;
	public long Rank { get; init; }
	
	public record ClanMemberRole
	{
		public long Order { get; init; }
		public long Rank { get; init; }
		public string Name { get; init; } = string.Empty;
	}
}