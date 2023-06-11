using JetBrains.Annotations;

namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

[PublicAPI]
public record ClanStatistics
{
	public float? BattlesCount { get; set; }
	public float? WinsPercentage { get; set; }
	public float? ExpPerBattle { get; set; }
	public float? DamagePerBattle { get; set; }
}