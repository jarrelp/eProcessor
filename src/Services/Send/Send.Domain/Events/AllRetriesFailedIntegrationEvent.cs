using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

public record AllRetriesFailedIntegrationEvent : IntegrationEvent
{
    public AllRetriesFailedIntegrationEvent(int emailQueueId, string errorMessage)
    {
        EmailQueueId = emailQueueId;
        ErrorMessage = errorMessage;
    }

    public int EmailQueueId { get; init; }
    public string ErrorMessage { get; init; } = null!;
}
