using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;

public record EmailIsSendIntegrationEvent(int EmailQueueId, DateTime Timestamp) : IntegrationEvent;
