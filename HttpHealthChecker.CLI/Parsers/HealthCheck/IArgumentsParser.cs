using HttpHealthChecker.Domain.UseCases.Healthcheck;

namespace HttpHealthChecker.CLI.Parsers.HealthCheck;

internal interface IArgumentsParser
{
    HealthCheckCommand ParseHealthCheckCommand(string[] args);
}