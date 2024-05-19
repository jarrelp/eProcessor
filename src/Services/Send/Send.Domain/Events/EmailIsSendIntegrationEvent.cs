using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

public record EmailIsSendIntegrationEvent : IntegrationEvent
{
    public EmailIsSendIntegrationEvent(int emailQueueId)
    {
        EmailQueueId = emailQueueId;
        Timestamp = DateTime.UtcNow;
    }

    public int EmailQueueId { get; init; }
    public DateTime Timestamp { get; init; }
}
