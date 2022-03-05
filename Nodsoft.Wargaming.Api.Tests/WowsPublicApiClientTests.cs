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
using NUnit.Framework;

namespace Nodsoft.Wargaming.Api.Tests;

public class WowsPublicApiClientTests
{
	private IServiceProvider _services = null!;
	
	[SetUp]
	public void Setup()
	{
		IServiceCollection services = new ServiceCollection();
		
		services.AddSingleton(new PublicApiOptions { AppId = "17664662df5b8c87b890dc0e33db92d4" });
		services.AddThrottledApiClient<WowsPublicApiClient>((_, client) =>
		{
			client.BaseAddress = new(ApiHostUtilities.GetApiHost(Game.WOWS, Region.EU));
		}, 10);

		_services = services.BuildServiceProvider();
	}

	[Test]
	public async Task ListPlayersAsync_Nominal()
	{
		WowsPublicApiClient client = _services.GetRequiredService<WowsPublicApiClient>();

		IEnumerable<AccountListing>? results = (await client.ListPlayersAsync("Sakura_Isayeki"))?.Data;

		Assert.IsNotEmpty(results);
		Assert.IsTrue(results.Any(x => x.AccountId == 503379282));
	}
	
	[Test]
	public async Task FetchPlayersAsync_Nominal()
	{
		WowsPublicApiClient client = _services.GetRequiredService<WowsPublicApiClient>();

		const int accountId = 503379282;
		Dictionary<uint, AccountInfo>? results = (await client.FetchPlayersAsync(new uint[] { accountId }))?.Data;

		Assert.IsNotEmpty(results);
		Assert.IsTrue(results.ContainsKey(accountId));
	}
}