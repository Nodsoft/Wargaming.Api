namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Vortex;

public record VortexAccountInfo : Public.AccountInfo
{
	public VortexAccountStatistics Statistics { get; init; }
}