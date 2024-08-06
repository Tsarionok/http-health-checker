using MediatR;

namespace HttpHealthChecker.Domain.UseCases.Healthcheck;

/// <summary>
/// Represents a command for performing health checks with a specified interval between HTTP requests.
/// </summary>
/// <param name="IntervalBetweenRequests">
/// The interval in seconds between each HTTP request. This is a positive integer indicating the delay between consecutive requests.
/// </param>
/// <param name="Url">
/// The URL to which the health check HTTP requests will be sent. This should be a valid URL string.
/// </param>
/// <remarks>
/// Implements the <see cref="IRequest"/> interface to signal that this is a request in the context of a CQRS pattern.
/// </remarks>
public record HealthCheckCommand(int IntervalBetweenRequests, string Url) : IRequest;