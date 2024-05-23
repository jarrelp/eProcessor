using AutoMapper;
using Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;
using Moq;
using Microsoft.Extensions.Logging;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

namespace Ecmanage.eProcessor.Services.Process.tests.Process.Application.EventHandling;

public class OverdueIntegrationEventHandlerTests
{
    private readonly Mock<ILogger<OverdueIntegrationEventHandler>> _loggerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IEventBus> _eventBusMock;
    private readonly OverdueIntegrationEventHandler _handler;

    public OverdueIntegrationEventHandlerTests()
    {
        _loggerMock = new Mock<ILogger<OverdueIntegrationEventHandler>>();
        _mapperMock = new Mock<IMapper>();
        _eventBusMock = new Mock<IEventBus>();
        _handler = new OverdueIntegrationEventHandler(_loggerMock.Object, _mapperMock.Object, _eventBusMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldPublishEmailBodyIntegrationEvent()
    {
        // Arrange
        var overdueEvent = new OverdueIntegrationEvent(1, "John Doe", "john.doe@example.com", "12345", "Sample Product", "ORD001", "2024-05-01", "2024-05-21");
        var overdueDto = new OverdueDto { EmailQueueId = 1, EmailFrom = "no-reply@example.com", EmailTo = "john.doe@example.com", Subject = "Overdue Notice", FullName = "John Doe", Email = "john.doe@example.com", ProductNumber = "12345", ProductName = "Sample Product", OrderCode = "ORD001", OrderDate = "2024-05-01", OverdueDate = "2024-05-21" };
        var emailBodyDto = new EmailBodyDto { EmailBody = "Email Body", EmailQueueId = 1, EmailFrom = "no-reply@example.com", EmailTo = "john.doe@example.com", Subject = "Overdue Notice" };
        var emailBodyEvent = new EmailBodyIntegrationEvent("Email Body");

        _mapperMock.Setup(m => m.Map<OverdueDto>(overdueEvent)).Returns(overdueDto);
        _mapperMock.Setup(m => m.Map<EmailBodyIntegrationEvent>(It.IsAny<EmailBodyDto>())).Returns(emailBodyEvent);

        // Act
        await _handler.Handle(overdueEvent, CancellationToken.None);

        // Assert
        _eventBusMock.Verify(e => e.PublishAsync(emailBodyEvent, CancellationToken.None), Times.Once);
    }
}