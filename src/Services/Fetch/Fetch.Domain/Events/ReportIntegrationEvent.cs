using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;

public record ReportIntegrationEvent(int EmailId, string PortalName, string ReportName, string Url) : IntegrationEvent;
