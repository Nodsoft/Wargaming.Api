namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Public;

public record ClanListing
{
	public uint ClanId { get; init; }
	
	public string Tag { get; init; } = string.Empty;

	public string Name { get; init; } = string.Empty;
	
	public ushort MembersCount { get; init; }
	
	public int Color { get; init; }
}