﻿using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Nodsoft.Wargaming.Api.Client.Infrastructure;
using Nodsoft.Wargaming.Api.Client.Infrastructure.Converters;

namespace Nodsoft.Wargaming.Api.Client.Clients;

[MeansImplicitUse(ImplicitUseTargetFlags.WithInheritors)]
public abstract class ApiClientBase : IApiClient
{
	protected HttpClient Client { get; init; }

	protected static JsonSerializerOptions SerializerOptions { get; } = new()
	{
		PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
		PropertyNameCaseInsensitive = true,
		NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals | JsonNumberHandling.AllowReadingFromString,
		Converters =
		{
			new RegionsJsonEnumConverter(),
			new ClanRolesJsonEnumConverter(), 
			new JsonStringEnumConverter(SnakeCaseNamingPolicy.Instance)
		}
	};

	protected ApiClientBase(HttpClient client)
	{
		Client = client;
	}

}