using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;

public record SendEmailAttemptIntegrationEvent : IntegrationEvent
{
    public int EmailQueueId { get; init; }
    public int Attempt { get; init; }

    public SendEmailAttemptIntegrationEvent(int emailQueueId, int attempt)
    {
        EmailQueueId = emailQueueId;
        Attempt = attempt;
    }
}
