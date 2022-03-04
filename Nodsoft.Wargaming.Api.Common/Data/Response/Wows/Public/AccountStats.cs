namespace Nodsoft.Wargaming.Api.Common.Data.Response.Wows.Public;

public record AccountStats
{
	// fields=pve.battles,pve.damage_dealt,pve.frags,pve.wins,pve.xp

	public int Battles
	{
		get => WgBattles ?? VortexBattles ?? 0;
		init
		{
			if (WgBattles.HasValue)
			{
				WgBattles = value;
			}
			else
			{
				VortexBattles = value;
			}
		}
	}

	public int? VortexBattles { get; init; }
	public int? WgBattles { get; init; }

	public long Xp
	{
		get => WgXp ?? VortexXp ?? 0;
		init
		{
			if (WgXp.HasValue)
			{
				WgXp = value;
			}
			else
			{
				VortexXp = value;
			}
		}
	}

	public long? VortexXp { get; init; }
	public long? WgXp { get; init; }

	public int Wins { get; init; }

	public long Damage { get; init; }

	public int Frags { get; init; }

//		public MatchGroup StatsType { get; set; }
}