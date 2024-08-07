using HttpHealthChecker.CLI;
using HttpHealthChecker.CLI.Parsers.HealthCheck;
using HttpHealthChecker.Domain.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddScoped<ConsoleController>();
services.AddScoped<IArgumentsParser, ArgumentsParser>();
services.AddScoped<HttpClient>();
services.AddHealthCheckerDomain();

var serviceProvider = services.BuildServiceProvider();
var controller = serviceProvider.GetRequiredService<ConsoleController>();

// TODO: encapsulate this
using var cts = new CancellationTokenSource();
var cancellationToken = cts.Token;
var task = controller.HealthCheck(args, cancellationToken);

try
{
    await task;
}
catch (OperationCanceledException)
{
    Console.WriteLine("Operation was cancelled.");
}