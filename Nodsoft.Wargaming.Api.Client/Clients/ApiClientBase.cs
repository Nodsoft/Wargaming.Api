using System.Text.Json;
using System.Text.Json.Serialization;
using Nodsoft.Wargaming.Api.Client.Infrastructure;
using Nodsoft.Wargaming.Api.Client.Infrastructure.Converters;

namespace Nodsoft.Wargaming.Api.Client.Clients;

public abstract class ApiClientBase : IApiClient
{
	protected HttpClient Client { get; init; }

	protected static JsonSerializerOptions SerializerOptions { get; } = new()
	{
		PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
		PropertyNameCaseInsensitive = true,
		NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals | JsonNumberHandling.AllowReadingFromString,
		Converters = { new ClanRolesJsonEnumConverter(), new JsonStringEnumConverter(SnakeCaseNamingPolicy.Instance) }
	};
	
	public ApiClientBase(HttpClient client)
	{
		Client = client;
	}

}