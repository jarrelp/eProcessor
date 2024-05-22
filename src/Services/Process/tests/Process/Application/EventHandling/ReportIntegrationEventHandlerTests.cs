using AutoMapper;
using Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;
using Moq;
using Microsoft.Extensions.Logging;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

namespace Ecmanage.eProcessor.Services.Process.tests.Process.Application.EventHandling;

public class ReportIntegrationEventHandlerTests
{
    private readonly Mock<ILogger<ReportIntegrationEventHandler>> _loggerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IEventBus> _eventBusMock;
    private readonly ReportIntegrationEventHandler _handler;

    public ReportIntegrationEventHandlerTests()
    {
        _loggerMock = new Mock<ILogger<ReportIntegrationEventHandler>>();
        _mapperMock = new Mock<IMapper>();
        _eventBusMock = new Mock<IEventBus>();
        _handler = new ReportIntegrationEventHandler(_loggerMock.Object, _mapperMock.Object, _eventBusMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldPublishEmailBodyIntegrationEvent()
    {
        // Arrange
        var reportEvent = new ReportIntegrationEvent(1, "Sample Portal", "Sample Report", "http://example.com");
        var reportDto = new ReportDto { EmailQueueId = 1, EmailFrom = "no-reply@example.com", EmailTo = "user@example.com", Subject = "Report Notice", PortalName = "Sample Portal", ReportName = "Sample Report", Url = "http://example.com" };
        var emailBodyDto = new EmailBodyDto { EmailBody = "Email Body", EmailQueueId = 1, EmailFrom = "no-reply@example.com", EmailTo = "user@example.com", Subject = "Report Notice" };
        var emailBodyEvent = new EmailBodyIntegrationEvent("Email Body");

        _mapperMock.Setup(m => m.Map<ReportDto>(reportEvent)).Returns(reportDto);
        _mapperMock.Setup(m => m.Map<EmailBodyIntegrationEvent>(It.IsAny<EmailBodyDto>())).Returns(emailBodyEvent);

        // Act
        await _handler.Handle(reportEvent);

        // Assert
        _eventBusMock.Verify(e => e.PublishAsync(emailBodyEvent), Times.Once);
    }
}
