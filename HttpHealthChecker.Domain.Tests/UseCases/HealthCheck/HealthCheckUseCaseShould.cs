using HttpHealthChecker.Domain.UseCases.Healthcheck;
using Moq;
using Moq.Language.Flow;

namespace HttpHealthChecker.Domain.Tests.UseCases.HealthCheck;

public class HealthCheckUseCaseShould
{
    private readonly HealthCheckUseCase _sut;
    private readonly ISetup<HttpClient,Task<HttpResponseMessage>> _sendHttpRequestSetup;

    public HealthCheckUseCaseShould()
    {
        var httpClient = new Mock<HttpClient>();
        _sendHttpRequestSetup = httpClient.Setup(client => client.SendAsync(It.IsAny<HttpRequestMessage>()));

        _sut = new HealthCheckUseCase(new HealthCheckCommandValidator(), httpClient.Object);
    }
}