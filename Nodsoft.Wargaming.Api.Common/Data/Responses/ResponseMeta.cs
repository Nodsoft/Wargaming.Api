using JetBrains.Annotations;

namespace Nodsoft.Wargaming.Api.Common.Data.Responses;

[PublicAPI]
public sealed record ResponseMeta
{
	public int? Count { get; init; }
}