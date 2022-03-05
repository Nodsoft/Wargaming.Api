namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Public
{
	public record AccountInfoWrapper
	{
		public bool HiddenProfile { get; init; }
		public AccountStats[] Stats { get; init; }
	}
}