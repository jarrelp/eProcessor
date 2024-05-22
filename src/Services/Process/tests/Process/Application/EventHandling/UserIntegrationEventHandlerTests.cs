using AutoMapper;
using Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;
using Moq;
using Microsoft.Extensions.Logging;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

namespace Ecmanage.eProcessor.Services.Process.tests.Process.Application.EventHandling;

public class UserIntegrationEventHandlerTests
{
    private readonly Mock<ILogger<UserIntegrationEventHandler>> _loggerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IEventBus> _eventBusMock;
    private readonly UserIntegrationEventHandler _handler;

    public UserIntegrationEventHandlerTests()
    {
        _loggerMock = new Mock<ILogger<UserIntegrationEventHandler>>();
        _mapperMock = new Mock<IMapper>();
        _eventBusMock = new Mock<IEventBus>();
        _handler = new UserIntegrationEventHandler(_loggerMock.Object, _mapperMock.Object, _eventBusMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldPublishEmailBodyIntegrationEvent()
    {
        // Arrange
        var userEvent = new UserIntegrationEvent(1, "Sample Header", "user@example.com", "John Doe", "johndoe", "password123", "Sample Company", "http://example.com");
        var userDto = new UserDto { EmailQueueId = 1, EmailFrom = "no-reply@example.com", EmailTo = "user@example.com", Subject = "Welcome", ImageHeader = "Sample Header", FullName = "John Doe", UserName = "johndoe", Password = "password123", Company = "Sample Company", Url = "http://example.com" };
        var emailBodyDto = new EmailBodyDto { EmailBody = "Email Body", EmailQueueId = 1, EmailFrom = "no-reply@example.com", EmailTo = "user@example.com", Subject = "Welcome" };
        var emailBodyEvent = new EmailBodyIntegrationEvent("Email Body");

        _mapperMock.Setup(m => m.Map<UserDto>(userEvent)).Returns(userDto);
        _mapperMock.Setup(m => m.Map<EmailBodyIntegrationEvent>(It.IsAny<EmailBodyDto>())).Returns(emailBodyEvent);

        // Act
        await _handler.Handle(userEvent);

        // Assert
        _eventBusMock.Verify(e => e.PublishAsync(emailBodyEvent), Times.Once);
    }
}