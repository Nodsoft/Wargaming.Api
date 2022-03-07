namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanInfo
{
	public bool IsDisbanded { get; init; }
	public long Leveling { get; init; }
	public string RecruitingPolicy { get; init; } = string.Empty;
	public string Color { get; init; } = string.Empty;
	public string Name { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
	public string Tag { get; init; } = string.Empty;
	public object[]? PreModeration { get; init; }
	public bool IsApplicationSent { get; init; }
	public ClanRecruitingRestrictions RecruitingRestrictions { get; init; } = new();
	public bool IsSuitedForAutorecruiting { get; init; }
	public long MembersCount { get; init; }
	public object[]? ActiveInvites { get; init; }
	public object[]? ActiveApplications { get; init; }
	public bool IsInviteReceived { get; init; }
	public DateTimeOffset CreatedAt { get; init; }
	public long MaxMembersCount { get; init; }
	public string RawDescription { get; init; } = string.Empty;
	public long? PersonalResource { get; init; }
	public long? AccumulativeResource { get; init; }
	public string Motto { get; init; } = string.Empty;
	public Dictionary<string, long> Stats { get; init; } = new();
	public uint Id { get; init; }
}