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
	private WowsVortexApiClient _client = null!;
	
	[SetUp]
	public void Setup()
	{
		IServiceCollection services = new ServiceCollection();
		
		services.AddSingleton(new PublicApiOptions { AppId = "17664662df5b8c87b890dc0e33db92d4" });
		services.AddApiClient<WowsVortexApiClient>((_, client) => client.BaseAddress = new(WowsVortexApiClient.GetApiHost(Region.EU)));

		_services = services.BuildServiceProvider();
		_client = _services.GetRequiredService<WowsVortexApiClient>();
	}

	[Test]
	public async Task FetchAccountAsync_Nominal()
	{
		const int accountId = 503379282;
		VortexAccountInfo? results = await _client.FetchAccountAsync(accountId);

		Assert.IsNotNull(results);
		Assert.IsTrue(results!.AccountId == accountId);
	}
	
	[Test]
	public async Task FetchAccountsAsync_Nominal()
	{
		uint[] ids = { 503379282, 534767817 };
		Dictionary<uint, VortexAccountInfo?> results = await _client.FetchAccountsAsync(ids);
		
		Assert.IsNotEmpty(results);
		Assert.IsTrue(results.All(x 
			=> ids.Contains(x.Value?.AccountId ?? 0)
			&& x.Key == x.Value?.AccountId));
	}
	
	[Test]
	public async Task FetchAccountClanAsync_Nominal()
	{
		const int accountId = 503379282;
		VortexAccountClanInfo? results = await _client.FetchAccountClanAsync(accountId);

		Assert.IsNotNull(results);
		Assert.IsNotNull(results!.Clan);
	}
	
	[Test]
	public async Task FetchAccountsClansAsync_Nominal()
	{
		uint[] ids = { 503379282, 534767817 };
		Dictionary<uint, VortexAccountClanInfo?> results = await _client.FetchAccountsClansAsync(ids);
		
		Assert.IsNotEmpty(results);
		Assert.IsTrue(results.All(x => ids.Contains(x.Key)));
	}
}