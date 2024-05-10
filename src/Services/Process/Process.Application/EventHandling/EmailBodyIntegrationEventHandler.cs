using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;

public class EmailBodyIntegrationEventHandler : IIntegrationEventHandler<EmailBodyIntegrationEvent>
{
    private readonly ILogger<EmailBodyIntegrationEvent> _logger;

    public EmailBodyIntegrationEventHandler(ILogger<EmailBodyIntegrationEvent> logger)
    {
        _logger = logger;
    }

    public Task Handle(EmailBodyIntegrationEvent @event)
    {
        _logger.LogInformation("--------------------------------------------------------------------------------------------------------------------");
        _logger.LogInformation("EmailBodyIntegrationEvent Attributes:");
        _logger.LogInformation($"  EmailBody: {@event.EmailBody}");
        _logger.LogInformation("--------------------------------------------------------------------------------------------------------------------");
        return Task.CompletedTask;
    }
}