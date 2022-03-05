using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	private WowsPublicApiClient _client = null!;
	
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
		_client = _services.GetRequiredService<WowsPublicApiClient>();
	}

	[Test]
	public async Task ListPlayersAsync_Nominal()
	{
		AccountListing[]? results = (await _client.ListPlayersAsync("Sakura_Isayeki"))?.Data?.ToArray();

		Assert.IsNotNull(results);
		Assert.IsNotEmpty(results!);
		Assert.IsTrue(results!.Any(x => x.AccountId == 503379282));
	}
	
	[Test]
	public async Task FetchPlayersAsync_Nominal()
	{
		const int accountId = 503379282;
		Dictionary<uint, AccountInfo>? results = (await _client.FetchPlayersAsync(new uint[] { accountId }))?.Data;

		Assert.IsNotNull(results);
		Assert.IsNotEmpty(results!);
		Assert.IsTrue(results!.ContainsKey(accountId));
	}
	
	[Test]
	public async Task ListClansAsync_Nominal()
	{
		ClanListing[]? results = (await _client.ListClansAsync("Stormshock"))?.Data?.ToArray();

		Assert.IsNotNull(results);
		Assert.IsNotEmpty(results!);
		Assert.IsTrue(results!.Any(x => x.ClanId == 500186529));
	}
	
	[Test]
	public async Task FetchClansAsync_Nominal()
	{
		const int clanId = 500186529;
		Dictionary<uint, ClanInfo>? results = (await _client.FetchClansAsync(new uint[] { clanId }))?.Data;

		Assert.IsNotNull(results);
		Assert.IsNotEmpty(results!);
		Assert.IsTrue(results!.ContainsKey(clanId));
	}
}