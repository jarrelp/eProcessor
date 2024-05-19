namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

public record ReportIntegrationEvent(int EmailQueueId, int EmailId, string PortalName, string ReportName, string Url, string EmailTo, string Subject) : BaseEmailIntegrationEvent(EmailQueueId, EmailTo, Subject);
