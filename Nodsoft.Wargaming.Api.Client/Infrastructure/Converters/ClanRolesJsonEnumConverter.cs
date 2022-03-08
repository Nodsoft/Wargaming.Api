using System.Text.Json;
using System.Text.Json.Serialization;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows;

namespace Nodsoft.Wargaming.Api.Client.Infrastructure.Converters;

public class ClanRolesJsonEnumConverter : JsonConverter<ClanRole>
{
	public override ClanRole Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.GetString().ParseClanRole();

	public override void Write(Utf8JsonWriter writer, ClanRole value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToInternalString());
}