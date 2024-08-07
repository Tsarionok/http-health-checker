using HttpHealthChecker.CLI.Parsers.HealthCheck;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HttpHealthChecker.CLI;

internal class ConsoleController(
    IServiceScopeFactory serviceScopeFactory,
    IArgumentsParser argumentsParser,
    IMediator mediator)
{
    public async Task HealthCheck(string[] args, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            using var scope = serviceScopeFactory.CreateScope();
            
            var healthCheckCommand = argumentsParser.ParseHealthCheckCommand(args);
            await mediator.Send(healthCheckCommand, cancellationToken);
        }
    }
}