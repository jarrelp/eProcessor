namespace Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

public record EmailBodyIntegrationEvent(string EmailBody) : BaseEmailIntegrationEvent;
