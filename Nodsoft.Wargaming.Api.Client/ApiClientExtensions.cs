using System.Net;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Nodsoft.Wargaming.Api.Client.Clients;
using Nodsoft.Wargaming.Api.Client.Infrastructure;
using Nodsoft.Wargaming.Api.Client.Infrastructure.Throttling;

namespace Nodsoft.Wargaming.Api.Client;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ApiClientExtensions
{
	/// <summary>
	/// Adds an API client of type <see cref="TClient"/> to the <see cref="IServiceCollection"/>.
	/// </summary>
	/// <param name="services">The <see cref="IServiceCollection"/> to add the API client to.</param>
	/// <param name="configureClient">A callback to configure the API client.</param>
	/// <typeparam name="TClient">The type of the API client.</typeparam>
	/// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
	public static IHttpClientBuilder AddApiClient<TClient>(this IServiceCollection services, Action<IServiceProvider, HttpClient> configureClient) 
		where TClient : class, IApiClient 
		=> services.AddHttpClient<TClient>(configureClient)
			.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
			{
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.None
			});

	/// <summary>
	/// Adds an API client of type <see cref="TClient"/> to the <see cref="IServiceCollection"/>.
	/// </summary>
	/// <param name="services">The <see cref="IServiceCollection"/> to add the API client to.</param>
	/// <param name="configureClient">A callback to configure the API client.</param>
	/// <param name="maxConcurrentRequests">The maximum number of concurrent requests to allow.</param>
	/// <typeparam name="TClient">The type of the API client.</typeparam>
	/// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
	public static IHttpClientBuilder AddThrottledApiClient<TClient>(this IServiceCollection services, 
		Action<IServiceProvider, HttpClient> configureClient, ushort maxConcurrentRequests)
		where TClient : class, IApiClient 
		=> services.AddApiClient<TClient>(configureClient)
				.AddHttpMessageHandler(() => new ThrottledHandler(maxConcurrentRequests));
}