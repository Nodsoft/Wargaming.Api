namespace Nodsoft.Wargaming.Api.Common.Data.Responses.Wows;

public enum ClanRole : byte
{
	Unknown,
	Commander,
	ExecutiveOfficer,
	RecruitmentOfficer,
	CommissionedOfficer,
	Officer,
	Private
}

public static class ClanRoleExtensions
{
	public static ClanRole ParseClanRole(this string? value) => value switch
	{
		"commander"            => ClanRole.Commander,
		"executive_officer"    => ClanRole.ExecutiveOfficer,
		"recruitment_officer"  => ClanRole.RecruitmentOfficer,
		"commissioned_officer" => ClanRole.CommissionedOfficer,
		"officer"              => ClanRole.Officer,
		"private"              => ClanRole.Private,
		_                      => ClanRole.Unknown
	};
	
	public static string ToInternalString(this ClanRole value) => value switch
	{
		ClanRole.Commander           => "commander",
		ClanRole.ExecutiveOfficer    => "executive_officer",
		ClanRole.RecruitmentOfficer  => "recruitment_officer",
		ClanRole.CommissionedOfficer => "commissioned_officer",
		ClanRole.Officer             => "officer",
		ClanRole.Private             => "private",
		_                            => "unknown"
	};
}