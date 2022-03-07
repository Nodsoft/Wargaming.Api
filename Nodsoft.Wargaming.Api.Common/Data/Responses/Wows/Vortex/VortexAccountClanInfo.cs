using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Public;

namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Vortex;

public class VortexAccountClanInfo
{
	public ClanListing? Clan { get; init; }
	
	public DateTime? JoinedAt { get; init; }
	
	public ClanRole Role { get; init; }

	public uint? ClanId { get; set; }
}