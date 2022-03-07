namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanMembersView
{
	public ClanStatistics ClanStatistics { get; init; } = null!;
	public ClanMember[]? Items { get; init; }
	public bool IsHiddenStatistics { get; init; }
	public string Status { get; init; } = string.Empty;
	public DateTimeOffset LastUpdatedAt { get; init; }
}

public class ClanStatistics
{
	public double BattlesCount { get; set; }
	public double WinsPercentage { get; set; }
	public double ExpPerBattle { get; set; }
	public double DamagePerBattle { get; set; }
}

public record ClanMember
{
	public ClanMemberRole Role { get; init; } = null!;
	public bool IsPress { get; init; }
	public bool IsHiddenStatistics { get; init; }
	public long LastBattleTime { get; init; }
	public double ExpPerBattle { get; init; }
	public long? AccumulativeClanResource { get; init; }
	public double DamagePerBattle { get; init; }
	public Uri ProfileLink { get; init; } = null!;
	public bool IsBanned { get; init; }
	public long SeasonId { get; init; }
	public bool? IsBonusActivated { get; init; }
	public long DaysInClan { get; init; }
	public double FragsPerBattle { get; init; }
	public bool AbnormalResults { get; init; }
	public object? SeasonRank { get; init; }
	public long? Leveling { get; init; }
	public bool OnlineStatus { get; init; }
	public long Id { get; init; }
	public long BattlesCount { get; init; }
	public double BattlesPerDay { get; init; }
	public double WinsPercentage { get; init; }
	public string Name { get; init; } = string.Empty;
	public long Rank { get; init; }
	
	public record ClanMemberRole
	{
		public long Order { get; init; }
		public long Rank { get; init; }
		public string Name { get; init; } = string.Empty;
	}
}