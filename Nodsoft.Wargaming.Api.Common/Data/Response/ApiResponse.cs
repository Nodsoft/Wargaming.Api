namespace Nodsoft.Wargaming.Api.Common.Data.Response;

/// <summary>
/// Loosely-typed / Generic API Response template.
/// </summary>
/// <remarks>
/// Use <see cref="ApiResponse{TData}"/> for strong-typing.
/// </remarks>
public record ApiResponse
{
	public string Status { get; init; }

	public ResponseMeta Meta { get; init; }

	public object Data { get; init; }
}

/// <summary>
/// Strongly-typed / Defined API Response template.
/// </summary>
/// <remarks>
/// Use <see cref="ApiResponse"/> for generic-typing.
/// </remarks>
/// <typeparam name="TData">Model type of the Response's Data</typeparam>
public record ApiResponse<TData>
{
	public string Status { get; init; }

	public ResponseMeta Meta { get; init; }

	public TData Data { get; init; }
}