using FluentAssertions;
using FluentValidation;
using HttpHealthChecker.Domain.UseCases.Healthcheck;

namespace HttpHealthChecker.Domain.Tests.UseCases.HealthCheck;

public class HealthCheckCommandValidatorShould
{
    private readonly HealthCheckCommandValidator _sut = new();

    [Fact]
    public async Task ReturnTrue_WhenCommandIsValid()
    {
        var validCommand = new HealthCheckCommand(3, "http://example.com");
        var actual = await _sut.ValidateAsync(validCommand);
        actual.IsValid.Should().BeTrue();
    }

    public static IEnumerable<object[]> GetInvalidCommands()
    {
        var validCommand = new HealthCheckCommand(10, "http://httpstat.us/500");

        yield return [validCommand with{IntervalBetweenRequests = 0}];
        yield return [validCommand with{IntervalBetweenRequests = -10}];
        yield return [validCommand with { Url = "qwerty//.asd" }];
        yield return [validCommand with { Url = "http:/example.asd" }];
    }
    
    [Theory]
    [MemberData(nameof(GetInvalidCommands))]
    public async Task ReturnFalse_WhenCommandIsNotValid(HealthCheckCommand command)
    {
        var actual = await _sut.ValidateAsync(command);
        actual.IsValid.Should().BeFalse();
    }
}