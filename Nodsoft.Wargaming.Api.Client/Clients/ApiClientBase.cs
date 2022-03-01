namespace Nodsoft.Wargaming.Api.Client.Clients;

public abstract class ApiClientBase : IApiClient
{
	protected HttpClient Client { get; set; }

	public ApiClientBase(HttpClient client)
	{
		Client = client;
	}
	
	
}