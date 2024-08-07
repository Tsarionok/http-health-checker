using HttpHealthChecker.Domain.UseCases.Healthcheck;

namespace HttpHealthChecker.CLI.Parsers.HealthCheck;

internal class ArgumentsParser : IArgumentsParser
{
    public HealthCheckCommand ParseHealthCheckCommand(string[] args)
    {
        // TODO: exceptions handling
        var interval = args[0];
        var url = args[1];

        return new HealthCheckCommand(int.Parse(interval), url);
    }
}