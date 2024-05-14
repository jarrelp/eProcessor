namespace Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

public record LoginIntegrationEvent(int EmailId, string FullName, string Environment, string Date, string Time) : BaseEmailIntegrationEvent;
