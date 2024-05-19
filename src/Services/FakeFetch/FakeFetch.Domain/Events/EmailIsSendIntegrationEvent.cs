using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

public record EmailIsSendIntegrationEvent(int EmailQueueId, DateTime Timestamp) : IntegrationEvent;
