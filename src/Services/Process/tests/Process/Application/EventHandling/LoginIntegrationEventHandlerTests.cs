using AutoMapper;
using Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;
using Moq;
using Microsoft.Extensions.Logging;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

namespace Ecmanage.eProcessor.Services.Process.tests.Process.Application.EventHandling;

public class LoginIntegrationEventHandlerTests
{
    private readonly Mock<ILogger<LoginIntegrationEventHandler>> _loggerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IEventBus> _eventBusMock;
    private readonly LoginIntegrationEventHandler _handler;

    public LoginIntegrationEventHandlerTests()
    {
        _loggerMock = new Mock<ILogger<LoginIntegrationEventHandler>>();
        _mapperMock = new Mock<IMapper>();
        _eventBusMock = new Mock<IEventBus>();
        _handler = new LoginIntegrationEventHandler(_loggerMock.Object, _mapperMock.Object, _eventBusMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldPublishEmailBodyIntegrationEvent()
    {
        // Arrange
        var loginEvent = new LoginIntegrationEvent(1, "John Doe", "Production", "2024-05-21", "10:00");
        var loginDto = new LoginDto
        {
            EmailQueueId = 1,
            EmailFrom = "test@test.com",

            EmailTo = "recipient@test.com",
            Subject = "Login",
            FullName = "John Doe",
            Environment = "Production",
            Date = "2024-05-21",
            Time = "10:00"
        };

        var emailBodyDto = new EmailBodyDto
        {
            EmailBody = "Email Body",
            EmailQueueId = 1,
            EmailFrom = "test@test.com",
            EmailTo = "recipient@test.com",
            Subject = "Login"
        };

        var emailBodyEvent = new EmailBodyIntegrationEvent("Email Body");

        _mapperMock.Setup(m => m.Map<LoginDto>(loginEvent)).Returns(loginDto);
        _mapperMock.Setup(m => m.Map<EmailBodyIntegrationEvent>(It.IsAny<EmailBodyDto>())).Returns(emailBodyEvent);

        // Act
        await _handler.Handle(loginEvent, CancellationToken.None);

        // Assert
        _eventBusMock.Verify(e => e.PublishAsync(emailBodyEvent, CancellationToken.None), Times.Once);
    }
}
