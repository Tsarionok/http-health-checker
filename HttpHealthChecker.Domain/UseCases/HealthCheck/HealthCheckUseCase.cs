using FluentValidation;
using MediatR;

namespace HttpHealthChecker.Domain.UseCases.Healthcheck;

internal class HealthCheckUseCase(IValidator<HealthCheckCommand> validator, HttpClient httpClient) : IRequestHandler<HealthCheckCommand, HealthCheckResult>
{
    // TODO: replace to constants responsibility component
    private const int MillisecondsInSecond = 1000;
    
    public async Task<HealthCheckResult> Handle(HealthCheckCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);
        
        while (!cancellationToken.IsCancellationRequested)
        {
            // TODO: encapsulate actions with console to another module
            Console.Write($"Checking '{request.Url}'. ");
            
            var response = await httpClient.SendAsync(
                new HttpRequestMessage(HttpMethod.Get, request.Url), cancellationToken);
            
            var messageCode = (int)response.StatusCode == 200 ? "OK" : "ERR";
            
            Console.Write($"Result {messageCode}({(int)response.StatusCode}){Environment.NewLine}");
            
            await Task.Delay(request.IntervalBetweenRequests * MillisecondsInSecond, cancellationToken);
        }

        return new HealthCheckResult();
    }
}