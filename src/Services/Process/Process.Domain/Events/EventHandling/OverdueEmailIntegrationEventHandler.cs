using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

public class OverdueIntegrationEventHandler : IIntegrationEventHandler<OverdueIntegrationEvent>
{
    private readonly ILogger<OverdueIntegrationEventHandler> _logger;

    public OverdueIntegrationEventHandler(ILogger<OverdueIntegrationEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(OverdueIntegrationEvent @event)
    {
        _logger.LogInformation("Overdue Template Attributes:");
        _logger.LogInformation($"  FullName: {@event.FullName}");
        _logger.LogInformation($"  Email: {@event.Email}");
        _logger.LogInformation($"  ProductNumber: {@event.ProductNumber}");
        _logger.LogInformation($"  ProductName: {@event.ProductName}");
        _logger.LogInformation($"  OrderCode: {@event.OrderCode}");
        _logger.LogInformation($"  OrderDate: {@event.OrderDate}");
        _logger.LogInformation($"  OverdueDate: {@event.OverdueDate}");
        return Task.CompletedTask;
    }
}