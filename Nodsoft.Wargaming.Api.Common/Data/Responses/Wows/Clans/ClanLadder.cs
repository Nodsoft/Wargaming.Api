namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanLadder
{
	public long BattlesCount { get; init; }
	public long LeadingTeamNumber { get; init; }
	public object? LastWinAt { get; init; }
	public bool IsDisbanded { get; init; }
	public long DivisionRating { get; init; }
	public object? RatingRealm { get; init; }
	public long Color { get; init; }
	public long Division { get; init; }
	public bool IsQualified { get; init; }
	public long TotalBattlesCount { get; init; }
	public long InitialPublicRating { get; init; }
	public ClanStatus Status { get; init; }
	public long MaxPublicRating { get; init; }
	public DateTimeOffset? LastBattleAt { get; init; }
	public long LongestWinningStreak { get; init; }
	public long CurrentWinningStreak { get; init; }
	public ClanMaxPosition MaxPosition { get; init; } = new();
	public long MembersCount { get; init; }
	public bool IsBestSeasonRating { get; init; }
	public ClanRating[]? Ratings { get; init; }
	public long League { get; init; }
	public long DivisionRatingMax { get; init; }
	public long SeasonNumber { get; init; }
	public object? PrimeTime { get; init; }
	public long PublicRating { get; init; }
	public long WinsCount { get; init; }
	public object? Realm { get; init; }
	public object? PlannedPrimeTime { get; init; }
	public long Id { get; init; }
	public long TeamNumber { get; init; }
	public bool IsBanned { get; init; }
}