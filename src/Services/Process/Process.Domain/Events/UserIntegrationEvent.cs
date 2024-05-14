namespace Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

public record UserIntegrationEvent(int EmailId, string ImageHeader, string Email, string FullName, string UserName, string Password, string Company, string Url) : BaseEmailIntegrationEvent;
