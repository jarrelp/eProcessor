using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;

public class UserIntegrationEventHandler : IIntegrationEventHandler<UserIntegrationEvent>
{
    private readonly ILogger<UserIntegrationEventHandler> _logger;

    public UserIntegrationEventHandler(ILogger<UserIntegrationEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserIntegrationEvent @event)
    {
        _logger.LogInformation("User Template Attributes:");
        _logger.LogInformation($"  ImageHeader: {@event.ImageHeader}");
        _logger.LogInformation($"  Email: {@event.Email}");
        _logger.LogInformation($"  FullName: {@event.FullName}");
        _logger.LogInformation($"  UserName: {@event.UserName}");
        _logger.LogInformation($"  Password: {@event.Password}");
        _logger.LogInformation($"  Company: {@event.Company}");
        _logger.LogInformation($"  Url: {@event.Url}");
        return Task.CompletedTask;
    }
}