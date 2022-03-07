namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanBuilding
{
	public long Level { get; init; }
	public string Name { get; init; } = string.Empty;
	public long Id { get; init; }
	public long[]? Modifiers { get; init; }
}