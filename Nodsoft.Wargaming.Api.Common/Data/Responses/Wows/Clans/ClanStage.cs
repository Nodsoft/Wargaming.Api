namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanStage
{
	public object? TargetDivisionRating { get; init; }
	public object? TargetPublicRating { get; init; }
	public object? TargetLeague { get; init; }
	public object? Battles { get; init; }
	public long Id { get; init; }
	public object? Target { get; init; }
	public object? BattleResultId { get; init; }
	public object? TargetDivision { get; init; }
	public object? VictoriesRequired { get; init; }
	public object[]? Progress { get; init; }
	public string Type { get; init; } = string.Empty;
}