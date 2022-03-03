﻿using Nodsoft.Wargaming.Api.Client;
using Nodsoft.Wargaming.Api.Client.Clients;
using Nodsoft.Wargaming.Api.Client.Clients.Wows;
using Nodsoft.Wargaming.Api.Common;

namespace Nodsoft.Wargaming.Api.Spike;

public static class Program
{
	public static async Task Main(string[] args)
	{
		IHost host = CreateHostBuilder(args).Build();

		WowsPublicApiClient client = host.Services.GetRequiredService<WowsPublicApiClient>();

		var result = await client.ListPlayersAsync("Sakura");


		await host.RunAsync();
	}

	public static IServiceCollection ConfigureServices(IServiceCollection services)
	{
		services.AddThrottledApiClient<WowsPublicApiClient>((_, client) =>
		{
			client.BaseAddress = new(ApiHostUtilities.GetApiHost(Game.WOWS, Region.EU));
		}, 20);

		services.AddSingleton(new PublicApiOptions { AppId = "17664662df5b8c87b890dc0e33db92d4" });

		return services;
	}
	
	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.ConfigureServices(services => ConfigureServices(services));
}