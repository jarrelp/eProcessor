namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

public record EmailBodyIntegrationEvent(string EmailBody) : BaseEmailIntegrationEvent;
