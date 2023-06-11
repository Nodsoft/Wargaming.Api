using System.Text.Json;

namespace Nodsoft.Wargaming.Api.Client.Infrastructure;

/// <summary>
/// Provides a JSON serialization policy to convert property names to <c>snake_case</c>.
/// </summary>
public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
	public static SnakeCaseNamingPolicy Instance { get; } = new();
	
	public override string ConvertName(string name) => name.ToSnakeCase();
}