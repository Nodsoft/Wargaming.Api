﻿using Nodsoft.Wargaming.Api.Common;

namespace Nodsoft.Wargaming.Api.Client;

public class ApiHostUtilities
{
	public static string GetApiHost(Game game, Region region) => ApiHosts[(int)game][(int)region];

	private static readonly string[][] ApiHosts = {
		// Wargaming.net
		new[]
		{
			"https://api.worldoftanks.eu/wgn/",
			"https://api.worldoftanks.com/wgn/",
			"https://api.worldoftanks.ru/wgn/",
			"https://api.worldoftanks.asia/wgn/"
		},

		// World Of Tanks
		new[]
		{
			"https://api.worldoftanks.eu/wot/",
			"https://api.worldoftanks.com/wot/",
			"https://api.worldoftanks.ru/wot/",
			"https://api.worldoftanks.asia/wot/"
		},

		// World Of Warships
		new[]
		{
			"https://api.worldofwarships.eu/wows/",
			"https://api.worldofwarships.com/wows/",
			"https://api.worldofwarships.ru/wows/",
			"https://api.worldofwarships.asia/wows/"
		},

		// World Of Warplanes
		new[]
		{
			"https://api.worldofwarplanes.eu/wowp/",
			"https://api.worldofwarplanes.com/wowp/",
			"https://api.worldofwarplanes.ru/wowp/",
			"https://api.worldofwarplanes.asia/wowp/"
		},
	};
}