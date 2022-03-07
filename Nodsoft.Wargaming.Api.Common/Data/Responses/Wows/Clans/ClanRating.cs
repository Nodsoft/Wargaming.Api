namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanRating
{
	public long BattlesCount { get; init; }
	public DateTimeOffset? LastWinAt { get; init; }
	public long DivisionRating { get; init; }
	public long Division { get; init; }
	public bool IsQualified { get; init; }
	public long InitialPublicRating { get; init; }
	public ClanStatus Status { get; init; }
	public long MaxPublicRating { get; init; }
	public long LongestWinningStreak { get; init; }
	public long CurrentWinningStreak { get; init; }
	public ClanMaxPosition? MaxPosition { get; init; }
	public bool IsBestSeasonRating { get; init; }
	public long League { get; init; }
	public long DivisionRatingMax { get; init; }
	public long SeasonNumber { get; init; }
	public ClanStage? Stage { get; init; }
	public long PublicRating { get; init; }
	public long WinsCount { get; init; }
	public Region? Realm { get; init; }
	public long? Id { get; init; }
	public long TeamNumber { get; init; }
}