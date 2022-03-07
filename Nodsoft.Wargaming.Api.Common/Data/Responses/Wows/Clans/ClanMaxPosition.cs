namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public record ClanMaxPosition
{
	public long PublicRating { get; init; }
	public long Division { get; init; }
	public long DivisionRating { get; init; }
	public long League { get; init; }
}