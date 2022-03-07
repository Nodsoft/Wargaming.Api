using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows;

namespace Nodsoft.Wargaming.Api.Client.Infrastructure;

public static class Utilities
{
	public static string ToSnakeCase(this string str) => string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? $"_{x}" : x.ToString())).ToLower();

	public static string ToClanQueryArgument(this BattleType battleType) => battleType switch
	{
		BattleType.Random       => "pvp",
		BattleType.Coop         => "pve",
		BattleType.Clans        => "cvc",
		BattleType.Ranked       => "rank_solo",
		BattleType.OldRanked    => "rank_old_solo",
		
		BattleType.Unknown or _ => throw new ArgumentOutOfRangeException(nameof(battleType), battleType, null)
	};
}