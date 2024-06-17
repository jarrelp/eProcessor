using AutoMapper;
using Dapr.Client;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Send.Send.Application.EventHandling;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ecmanage.eProcessor.Services.Send.tests.Send.Application.EventHandling;

public class EmailBodyIntegrationEventHandlerTests
{
    [Fact]
    public async Task Handle_EmailSendingFailed_PublishAllRetriesFailedIntegrationEvent()
    {

        var loggerMock = new Mock<ILogger<EmailBodyIntegrationEventHandler>>();
        var eventBusMock = new Mock<IEventBus>();
        var emailSnapshotServiceMock = new Mock<IEmailSnapshotService>();
        var mapperMock = new Mock<IMapper>();
        var configurationMock = new Mock<IConfiguration>();

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
            emailSnapshotServiceMock.Object,
            configurationMock.Object);

        var emailEvent = new EmailBodyIntegrationEvent("Test Body")
        {
            EmailQueueId = 1,
            EmailFrom = "from@example.com",
            EmailTo = "to@example.com",
            Subject = "Test Subject"
        };


        await Assert.ThrowsAsync<SendMailFailedException>(() =>
            handler.Handle(emailEvent, CancellationToken.None));
        eventBusMock.Verify(e =>
            e.PublishAsync(It.IsAny<AllRetriesFailedIntegrationEvent>(), CancellationToken.None), Times.Once);
    }
}