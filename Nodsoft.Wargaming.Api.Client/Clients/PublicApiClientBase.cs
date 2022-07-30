namespace Nodsoft.Wargaming.Api.Client.Clients;

/// <summary>
/// Provides a base class for all Wargaming Public API clients.
/// </summary>
public abstract class PublicApiClientBase : ApiClientBase
{
	/// <summary>
	/// Configuration options for the API client.
	/// </summary>
	public PublicApiOptions ApiOptions { protected get; init; }

	protected PublicApiClientBase(HttpClient client, PublicApiOptions apiOptions) : base(client) => ApiOptions = apiOptions;

	/// <summary>
	/// Gets the common query string parameters to use for all requests emitted by this client.
	/// </summary>	
	protected Dictionary<string, string> GetDefaultQueryParameters() => new()
	{
		["application_id"] = ApiOptions.AppId,
		["language"] = "en"
	};
}