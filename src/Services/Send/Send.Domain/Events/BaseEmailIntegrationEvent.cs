using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

public abstract record BaseEmailIntegrationEvent : IntegrationEvent
{
    public string EmailFrom { get; init; } = null!;
    public string EmailTo { get; init; } = null!;
    public string Subject { get; init; } = null!;
}
