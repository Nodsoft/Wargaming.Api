namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanRating
{
	public uint BattlesCount { get; init; }
	public DateTimeOffset? LastWinAt { get; init; }
	public ushort DivisionRating { get; init; }
	public ushort Division { get; init; }
	public bool IsQualified { get; init; }
	public long InitialPublicRating { get; init; }
	public ClanStatus Status { get; init; }
	public long MaxPublicRating { get; init; }
	public long LongestWinningStreak { get; init; }
	public long CurrentWinningStreak { get; init; }
	public ClanMaxPosition? MaxPosition { get; init; }
	public bool IsBestSeasonRating { get; init; }
	public ushort League { get; init; }
	public ushort DivisionRatingMax { get; init; }
	public ushort SeasonNumber { get; init; }
	public ClanStage? Stage { get; init; }
	public ushort PublicRating { get; init; }
	public uint WinsCount { get; init; }
	public Region? Realm { get; init; }
	public uint Id { get; init; }
	public byte TeamNumber { get; init; }
}