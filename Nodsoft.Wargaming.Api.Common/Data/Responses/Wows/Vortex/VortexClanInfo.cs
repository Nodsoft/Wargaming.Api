using System.Drawing;

namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Vortex;

public record VortexClanInfo
{
	public string Tag { get; init; } = string.Empty;

	public string Name { get; init; } = string.Empty;
	
	public ushort MembersCount { get; init; }
	
	public uint Color { get; init; }
}