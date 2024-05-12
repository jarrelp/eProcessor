using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

public record ReportIntegrationEvent(int EmailId, string PortalName, string ReportName, string Url) : IntegrationEvent;
