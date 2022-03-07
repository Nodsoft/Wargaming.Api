namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanRecruitingRestrictions
{
	public long BattlesCount { get; init; }
	public long WinRate { get; init; }
}