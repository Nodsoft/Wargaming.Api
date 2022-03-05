namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Vortex;

public class VortexAccountClanInfo
{
	public VortexClanInfo? Clan { get; set; }
	
	public DateTime? JoinedAt { get; init; }
	
	public string? Role { get; init; }

	public uint? ClanId { get; set; }
}