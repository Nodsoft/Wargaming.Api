using JetBrains.Annotations;

namespace Nodsoft.Wargaming.Api.Common.Data.Responses;

/// <summary>
/// Loosely-typed / Generic API Response template.
/// </summary>
/// <remarks>
/// Use <see cref="ApiResponse{TData}"/> for strong-typing.
/// </remarks>
public record ApiResponse : ApiResponse<object>;


/// <summary>
/// Strongly-typed / Defined API Response template.
/// </summary>
/// <remarks>
/// Use <see cref="ApiResponse"/> for generic-typing.
/// </remarks>
/// <typeparam name="TData">Model type of the Response's Data</typeparam>
[PublicAPI]
public record ApiResponse<TData>
{
	public string Status { get; init; } = string.Empty;

	public ResponseMeta? Meta { get; init; }

	public TData? Data { get; init; }

	public static implicit operator TData(ApiResponse<TData>? response) => response.Data;
}