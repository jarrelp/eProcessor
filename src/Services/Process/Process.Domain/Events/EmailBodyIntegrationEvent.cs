using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

public record EmailBodyIntegrationEvent(string EmailBody) : IntegrationEvent;
