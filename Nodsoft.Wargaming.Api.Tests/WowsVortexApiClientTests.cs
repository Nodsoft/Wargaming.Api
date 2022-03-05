using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Nodsoft.Wargaming.Api.Client;
using Nodsoft.Wargaming.Api.Client.Clients;
using Nodsoft.Wargaming.Api.Client.Clients.Wows;
using Nodsoft.Wargaming.Api.Common;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Public;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Vortex;
using NUnit.Framework;

namespace Nodsoft.Wargaming.Api.Tests;

public class WowsVortexApiClientTests
{
	private IServiceProvider _services = null!;
	
	[SetUp]
	public void Setup()
	{
		IServiceCollection services = new ServiceCollection();
		
		services.AddSingleton(new PublicApiOptions { AppId = "17664662df5b8c87b890dc0e33db92d4" });
		services.AddApiClient<WowsVortexApiClient>((_, client) => client.BaseAddress = new(WowsVortexApiClient.GetApiHost(Region.EU)));

		_services = services.BuildServiceProvider();
	}

	[Test]
	public async Task FetchAccountAsync_Nominal()
	{
		WowsVortexApiClient client = _services.GetRequiredService<WowsVortexApiClient>();

		const int accountId = 503379282;
		VortexAccountInfo? results = await client.FetchAccountAsync(accountId);

		Assert.IsNotNull(results);
		Assert.IsTrue(results!.AccountId == accountId);
	}
	
	[Test]
	public async Task FetchAccountsAsync_Nominal()
	{
		WowsVortexApiClient client = _services.GetRequiredService<WowsVortexApiClient>();

		uint[] ids = { 503379282, 534767817 };
		
		Dictionary<uint, VortexAccountInfo?> results = await client.FetchAccountsAsync(ids);

		Assert.IsNotEmpty(results);
		Assert.IsTrue(results.All(x => ids.Contains(x.Value?.AccountId ?? 0)));
	}
}