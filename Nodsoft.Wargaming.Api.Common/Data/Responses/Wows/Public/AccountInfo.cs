namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Public;

public record AccountInfo
{
	public string Nickname { get; init; } = string.Empty;

	public uint AccountId { get; init; }
	
	public string Name { get => Nickname; init => Nickname = value; }

	public float CreatedAt { get; init; }
	public DateTime CreatedAtTime => DateTime.UnixEpoch.AddSeconds(CreatedAt);

	public bool HiddenProfile { get; init; }
}