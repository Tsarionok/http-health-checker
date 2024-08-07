using FluentValidation;
using HttpHealthChecker.Domain.UseCases.Healthcheck;
using Microsoft.Extensions.DependencyInjection;

namespace HttpHealthChecker.Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHealthCheckerDomain(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<HealthCheckCommand>());

        services.AddScoped<IValidator<HealthCheckCommand>, HealthCheckCommandValidator>();
        
        return services;
    }
}