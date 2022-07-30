namespace Nodsoft.Wargaming.Api.Client.Clients;

/// <summary>
/// Options used to configure a <see cref="PublicApiClientBase"/> client.
/// </summary>
public record PublicApiOptions
{
	/// <summary>
	/// Application ID used to authenticate with the API.
	/// See: https://developers.wargaming.net/applications/
	/// </summary>
	public string AppId { internal get; init; } = string.Empty;
}