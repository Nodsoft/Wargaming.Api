using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Nodsoft.Wargaming.Api.Common;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows;

namespace Nodsoft.Wargaming.Api.Client.Infrastructure.Converters;

public class RegionsJsonEnumConverter : JsonConverter<Region>
{
	public override Region Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.GetString()?.ToLower(CultureInfo.InvariantCulture) switch
	{
		"eu"                    => Region.EU,
		"na" or "us"            => Region.NA,
		"ru" or "cis"           => Region.CIS,
		"asia" or "sea" or "sg" => Region.SEA,
		
		_                       => throw new ArgumentOutOfRangeException(reader.GetString(), "Invalid region specified.")
	};

	public override void Write(Utf8JsonWriter writer, Region value, JsonSerializerOptions options) => writer.WriteStringValue(value switch
	{
		Region.EU  => "eu",
		Region.NA  => "na",
		Region.CIS => "ru",
		Region.SEA => "asia",
		
		_          => throw new ArgumentOutOfRangeException(nameof(value), value, null)
	});
}