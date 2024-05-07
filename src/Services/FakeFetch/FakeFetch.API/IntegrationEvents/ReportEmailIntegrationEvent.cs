namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.IntegrationEvents;

public record ReportEmailIntegrationEvent(int EmailId, string PortalName, string ReportName, string Url) : IntegrationEvent;
