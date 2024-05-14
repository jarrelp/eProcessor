namespace Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

public record ReportIntegrationEvent(int EmailId, string PortalName, string ReportName, string Url) : BaseEmailIntegrationEvent;
