namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanMembersView
{
	public ClanStatistics ClanStatistics { get; init; } = null!;
	public ClanMember[]? Items { get; init; }
	public bool IsHiddenStatistics { get; init; }
	public string Status { get; init; } = string.Empty;
	public DateTimeOffset LastUpdatedAt { get; init; }
}