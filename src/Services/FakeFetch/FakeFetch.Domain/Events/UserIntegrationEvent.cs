namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

public record UserIntegrationEvent(int EmailQueueId, int EmailId, string ImageHeader, string Email, string FullName, string UserName, string Password, string Company, string Url, string EmailTo, string Subject) : BaseEmailIntegrationEvent(EmailQueueId, EmailTo, Subject);
