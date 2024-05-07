namespace Ecmanage.eProcessor.Services.Todo.Todo.API.IntegrationEvents;

public record ReportEmailIntegrationEvent(int EmailId, string PortalName, string ReportName, string Url) : IntegrationEvent;
