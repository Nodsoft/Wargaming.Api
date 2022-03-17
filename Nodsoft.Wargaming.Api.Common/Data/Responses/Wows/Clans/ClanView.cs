namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanViewWrapper
{
	public object? Meta { get; init; }
	public ClanView Clanview { get; init; }
}

public record ClanView
{
	public Dictionary<string, ClanBuilding> Buildings { get; init; } = new();
	public ClanInfo Clan { get; init; } = new();
	public ClanAchievement[]? Achievements { get; init; } = Array.Empty<ClanAchievement>();
	public ClanLadder? WowsLadder { get; init; }
}