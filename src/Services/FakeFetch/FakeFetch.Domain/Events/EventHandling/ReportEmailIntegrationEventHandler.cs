using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

public class ReportIntegrationEventHandler : IIntegrationEventHandler<ReportIntegrationEvent>
{
    private readonly ILogger<ReportIntegrationEventHandler> _logger;

    public ReportIntegrationEventHandler(ILogger<ReportIntegrationEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ReportIntegrationEvent @event)
    {
        _logger.LogInformation("Report Template Attributes:");
        _logger.LogInformation($"  PortalName: {@event.PortalName}");
        _logger.LogInformation($"  ReportName: {@event.ReportName}");
        _logger.LogInformation($"  Url: {@event.Url}");
        return Task.CompletedTask;
    }
}