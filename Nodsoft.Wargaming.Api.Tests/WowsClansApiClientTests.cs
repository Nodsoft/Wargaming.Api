using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Nodsoft.Wargaming.Api.Client;
using Nodsoft.Wargaming.Api.Client.Clients;
using Nodsoft.Wargaming.Api.Client.Clients.Wows;
using Nodsoft.Wargaming.Api.Common;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Public;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Vortex;
using NUnit.Framework;
using ClanInfo = Nodsoft.Wargaming.Api.Common.Data.Responses.Wows.Clans.ClanInfo;

namespace Nodsoft.Wargaming.Api.Tests;

public class WowsClansApiClientTests
{
	private IServiceProvider _services = null!;
	private WowsClansApiClient _client = null!;
	
	[SetUp]
	public void Setup()
	{
		IServiceCollection services = new ServiceCollection();
		
		services.AddSingleton(new PublicApiOptions { AppId = "17664662df5b8c87b890dc0e33db92d4" });
		services.AddApiClient<WowsClansApiClient>((_, client) => client.BaseAddress = new(WowsClansApiClient.GetApiHost(Region.EU)));

		_services = services.BuildServiceProvider();
		_client = _services.GetRequiredService<WowsClansApiClient>();
	}

	[Test]
	public async Task FetchClanViewAsync_Nominal()
	{
		const uint clanId = 500186529;
		ClanView? result = await _client.FetchClanViewAsync(clanId);

		Assert.IsNotNull(result);
		Assert.IsTrue(result!.Clan.Id == clanId);
	}
	
	[Test]
	public async Task FetchClanMembersAsync_Nominal()
	{
		const uint clanId = 500186529;
		ClanMembersView? result = await _client.FetchClanMembersAsync(clanId);

		Assert.IsNotNull(result);
		Assert.IsNotNull(result!.Items);
		Assert.IsNotEmpty(result.Items!);
	}

	[Test]
	public async Task SearchClansAsync_Nominal()
	{
		const uint clanId = 500186529;
		ClanSearchResults? result = await _client.SearchClansAsync("SGCX");

		Assert.IsNotNull(result);
		Assert.IsTrue(result!.Clans.Any(x => x.Id == clanId));
	}
}