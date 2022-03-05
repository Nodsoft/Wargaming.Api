namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Vortex;

public record VortexAccountStatistics
{
	public object? Clan { get; init; }
	public object? Pvp { get; init; }
	public object? Pve { get; init; }

	public BasicInfo? Basic { get; init; }
	
	public record BasicInfo
	{
		public int LevelingTier { get; init; }
		public long CreatedAt { get; init; }
		public int LevelingPoints { get; init; }
		public int Karma { get; init; }
		public long LastBattleTime { get; init; }
	}
}