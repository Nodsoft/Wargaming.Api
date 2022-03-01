namespace Nodsoft.Wargaming.Api.Client.Clients;

public abstract class PublicApiClientBase : ApiClientBase
{
	public PublicApiOptions ApiOptions { protected get; init; }

	public PublicApiClientBase(HttpClient client, PublicApiOptions apiOptions) : base(client)
	{
		ApiOptions = apiOptions;
	}

	public Dictionary<string, string> GetDefaultQueryParameters() => new()
	{
		["application_id"] = ApiOptions.AppId,
		["language"] = "en"
	};
}