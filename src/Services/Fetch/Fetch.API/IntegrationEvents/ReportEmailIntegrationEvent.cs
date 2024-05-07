namespace Ecmanage.eProcessor.Services.Fetch.Fetch.API.IntegrationEvents;

public record ReportEmailIntegrationEvent(int EmailId, string PortalName, string ReportName, string Url) : IntegrationEvent;
