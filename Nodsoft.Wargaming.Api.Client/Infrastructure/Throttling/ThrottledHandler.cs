namespace Nodsoft.Wargaming.Api.Client.Infrastructure.Throttling;

public class ThrottledHandler : DelegatingHandler
{
	protected TimeSpanSemaphore RequestSemaphore { get; }

	public ThrottledHandler(ushort maxConcurrentRequests)
	{
		// Process N.max requests per second.
		RequestSemaphore = new(maxConcurrentRequests, new(0, 0, 1));
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct) => 
		await RequestSemaphore.RunAsync(async (message, token) => await base.SendAsync(message, token), request, ct);
}