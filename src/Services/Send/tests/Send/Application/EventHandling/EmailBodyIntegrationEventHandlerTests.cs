using AutoMapper;
using Dapr.Client;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Send.Send.Application.EventHandling;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ecmanage.eProcessor.Services.Send.tests.Send.Application.EventHandling;

public class EmailBodyIntegrationEventHandlerTests
{
    [Fact]
    public async Task Handle_EmailSentSuccessfully_SaveEmailSnapshotAndPublishIntegrationEvents()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<EmailBodyIntegrationEventHandler>>();
        var eventBusMock = new Mock<IEventBus>();
        var emailSnapshotServiceMock = new Mock<IEmailSnapshotService>();
        var mapperMock = new Mock<IMapper>();

        var daprClientMock = new Mock<DaprClient>();
        daprClientMock.Setup(c => c.InvokeBindingAsync(
            It.IsAny<string>(), It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(),
            CancellationToken.None))
          .Returns(Task.CompletedTask);

        var handler = new EmailBodyIntegrationEventHandler(
            daprClientMock.Object,
            loggerMock.Object,
            eventBusMock.Object,
            mapperMock.Object,
            emailSnapshotServiceMock.Object);

        var emailEvent = new EmailBodyIntegrationEvent("Test Body")
        {
            EmailQueueId = 1,
            EmailFrom = "from@example.com",
            EmailTo = "to@example.com",
            Subject = "Test Subject"
        };

        // Act
        await handler.Handle(emailEvent);

        // Assert
        emailSnapshotServiceMock.Verify(
            s => s.SaveEmailSnapshotAsync(
                It.IsAny<EmailSnapshot>(),
                It.IsAny<CancellationToken>()
            ),
            Times.Once
        );
        eventBusMock.Verify(e => e.PublishAsync(It.IsAny<EmailIsSendIntegrationEvent>()), Times.Once);
    }

    [Fact]
    public async Task Handle_EmailSendingFailed_PublishAllRetriesFailedIntegrationEvent()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<EmailBodyIntegrationEventHandler>>();
        var eventBusMock = new Mock<IEventBus>();
        var emailSnapshotServiceMock = new Mock<IEmailSnapshotService>();
        var mapperMock = new Mock<IMapper>();

        var daprClientMock = new Mock<DaprClient>();
        daprClientMock.Setup(c => c.InvokeBindingAsync(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<Dictionary<string, string>>(),
            CancellationToken.None
        )).ThrowsAsync(new SendMailFailedException("Test"));

        var handler = new EmailBodyIntegrationEventHandler(
            daprClientMock.Object,
            loggerMock.Object,
            eventBusMock.Object,
            mapperMock.Object,
            emailSnapshotServiceMock.Object);

        var emailEvent = new EmailBodyIntegrationEvent("Test Body")
        {
            EmailQueueId = 1,
            EmailFrom = "from@example.com",
            EmailTo = "to@example.com",
            Subject = "Test Subject"
        };

        // Act & Assert
        await Assert.ThrowsAsync<SendMailFailedException>(() => handler.Handle(emailEvent));
        eventBusMock.Verify(e => e.PublishAsync(It.IsAny<AllRetriesFailedIntegrationEvent>()), Times.Once);
    }
}