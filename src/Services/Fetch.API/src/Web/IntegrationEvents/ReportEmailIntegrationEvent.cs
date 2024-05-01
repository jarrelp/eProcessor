namespace Ecmanage.eProcessor.Services.Fetch.API.Web.IntegrationEvents;

public record ReportEmailIntegrationEvent(int EmailId, string PortalName, string ReportName, string Url) : IntegrationEvent;
