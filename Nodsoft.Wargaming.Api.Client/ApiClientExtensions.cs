using System.Net;
using System.Net.Mime;
using Microsoft.Extensions.DependencyInjection;
using Nodsoft.Wargaming.Api.Client.Clients;

namespace Nodsoft.Wargaming.Api.Client;

public static class ApiClientExtensions
{
	public static IHttpClientBuilder AddApiClient<TClient>(this IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient) 
		where TClient : class, IApiClient
	{
		return services.AddHttpClient<TClient>(configureClient)
			.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
			{
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.None
			});
	}
}