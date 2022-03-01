using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Nodsoft.Wargaming.Api.Client.Clients;
using Nodsoft.Wargaming.Api.Client.Infrastructure;
using Nodsoft.Wargaming.Api.Client.Infrastructure.Throttling;

namespace Nodsoft.Wargaming.Api.Client;

public static class ApiClientExtensions
{
	public static IHttpClientBuilder AddApiClient<TClient>(this IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient) 
		where TClient : class, IApiClient =>
		services.AddHttpClient<TClient>(configureClient)
			.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
			{
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.None
			});

	public static IHttpClientBuilder AddThrottledApiClient<TClient>(this IServiceCollection services, 
		Action<IServiceProvider, HttpClient> configureClient, ushort maxConcurrentRequests)
		where TClient : class, IApiClient =>
			services.AddApiClient<TClient>(configureClient)
				.AddHttpMessageHandler(() => new ThrottledHandler(maxConcurrentRequests));
}