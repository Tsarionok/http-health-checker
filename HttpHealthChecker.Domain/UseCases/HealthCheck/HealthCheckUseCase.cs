using MediatR;

namespace HttpHealthChecker.Domain.UseCases.Healthcheck;

internal class HealthCheckUseCase(HttpClient httpClient) : IRequestHandler<HealthCheckCommand>
{
    public async Task Handle(HealthCheckCommand request, CancellationToken cancellationToken)
    {

    }
}