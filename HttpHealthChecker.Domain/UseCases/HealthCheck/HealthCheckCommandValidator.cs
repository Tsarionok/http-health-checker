using FluentValidation;

namespace HttpHealthChecker.Domain.UseCases.Healthcheck;

internal class HealthCheckCommandValidator : AbstractValidator<HealthCheckCommand>
{
    public HealthCheckCommandValidator()
    {
        RuleFor(command => command.IntervalBetweenRequests).GreaterThan(0);
        RuleFor(command => command.Url).Must(url => Uri.TryCreate(url, UriKind.Absolute, out _));
    }
}