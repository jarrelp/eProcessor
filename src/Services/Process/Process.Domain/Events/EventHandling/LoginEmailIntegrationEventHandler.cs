using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

public class LoginIntegrationEventHandler : IIntegrationEventHandler<LoginIntegrationEvent>
{
    private readonly ILogger<LoginIntegrationEventHandler> _logger;

    public LoginIntegrationEventHandler(ILogger<LoginIntegrationEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(LoginIntegrationEvent @event)
    {
        _logger.LogInformation("Login Template Attributes:");
        _logger.LogInformation($"  FullName: {@event.FullName}");
        _logger.LogInformation($"  Environment: {@event.Environment}");
        _logger.LogInformation($"  Date: {@event.Date}");
        _logger.LogInformation($"  Time: {@event.Time}");
        return Task.CompletedTask;
    }
}
