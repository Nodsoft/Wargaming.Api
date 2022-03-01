namespace Nodsoft.Wargaming.Api.Common.Data.Response.Wows.Public;

public record AccountInfo
{
	public string Nickname { get; init; }

	public uint AccountId { get; init; }
	
	public string Name { get => Nickname; init => Nickname = value; }

	public float CreatedAt { get; init; }
	public DateTime CreatedAtTime => DateTime.UnixEpoch.AddSeconds(CreatedAt);

	public object? Statistics { get; init; }

	public bool HiddenProfile { get; init; }
}