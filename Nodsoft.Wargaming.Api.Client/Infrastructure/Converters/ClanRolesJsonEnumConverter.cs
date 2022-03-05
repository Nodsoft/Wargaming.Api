using System.Text.Json;
using System.Text.Json.Serialization;
using Nodsoft.Wargaming.Api.Common.Data.Responses.Wows;

namespace Nodsoft.Wargaming.Api.Client.Infrastructure.Converters;

public class ClanRolesJsonEnumConverter : JsonConverter<ClanRole>
{
	public override ClanRole Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => reader.GetString() switch
	{
		"commander"            => ClanRole.Commander,
		"executive_officer"    => ClanRole.ExecutiveOfficer,
		"recruitment_officer"  => ClanRole.RecruitmentOfficer,
		"commissioned_officer" => ClanRole.CommissionedOfficer,
		"officer"              => ClanRole.Officer,
		"private"              => ClanRole.Private,
		_                      => ClanRole.Unknown
	};

	public override void Write(Utf8JsonWriter writer, ClanRole value, JsonSerializerOptions options) => writer.WriteStringValue(value switch
	{
		ClanRole.Commander           => "commander",
		ClanRole.ExecutiveOfficer    => "executive_officer",
		ClanRole.RecruitmentOfficer  => "recruitment_officer",
		ClanRole.CommissionedOfficer => "commissioned_officer",
		ClanRole.Officer             => "officer",
		ClanRole.Private             => "private",
		_                            => "unknown"
	});
}