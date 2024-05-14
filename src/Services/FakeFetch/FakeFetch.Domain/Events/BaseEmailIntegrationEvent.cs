using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

public abstract record BaseEmailIntegrationEvent : IntegrationEvent
{
    public string EmailFrom { get; init; } = "test@ecmanage.eu";
    public string EmailTo { get; init; } = null!;
    public string Subject { get; init; } = null!;

    protected BaseEmailIntegrationEvent(string emailTo, string subject)
    {
        EmailTo = emailTo;
        Subject = subject;
    }
}
