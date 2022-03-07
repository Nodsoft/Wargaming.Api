namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;

public class ClanSearchResults
{
	public ClanSearchListing[] Clans { get; set; } = Array.Empty<ClanSearchListing>();
}

public class ClanSearchListing
{
	public string Tag { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public ushort Leveling { get; set; }
	public uint Id { get; set; }
	public ushort MaxMembersCount { get; set; }
	public ushort MembersCount { get; set; }
	public Stats? TableFields { get; set; }
	public string HexColor { get; set; } = string.Empty;
	
	public class Stats
	{
		public float AverageXp { get; set; }
		public float AverageDamage { get; set; }
		public float AverageBattles { get; set; }
		public float AverageFrags { get; set; }
		public float AverageBattlesDaily { get; set; }
		public bool IsHiddenStatistics { get; set; }
		public float AverageWinsPercent { get; set; }
	}
}