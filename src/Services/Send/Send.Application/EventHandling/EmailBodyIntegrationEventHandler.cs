using Dapr.Client;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.EventHandling;

public class EmailBodyIntegrationEventHandler : IIntegrationEventHandler<EmailBodyIntegrationEvent>
{
    private const string SendMailBinding = "sendmail";
    private const string CreateBindingOperation = "create";

    private readonly DaprClient _daprClient;
    private readonly ILogger<EmailBodyIntegrationEvent> _logger;

    public EmailBodyIntegrationEventHandler(DaprClient daprClient, ILogger<EmailBodyIntegrationEvent> logger)
    {
        _daprClient = daprClient;
        _logger = logger;
    }

    public Task Handle(EmailBodyIntegrationEvent @event)
    {
        _logger.LogInformation("!send mail start!");
        return _daprClient.InvokeBindingAsync(
            SendMailBinding,
            CreateBindingOperation,
            @event.EmailBody,
            new Dictionary<string, string>
            {
                ["emailFrom"] = "eshopondapr@example.com",
                ["emailTo"] = "eshopondapr@example.com",
                ["subject"] = "Login Email"
            });
    }

    // public Task Handle(EmailBodyIntegrationEvent @event)
    // {
    //     _logger.LogInformation("--------------------------------------------------------------------------------------------------------------------");
    //     _logger.LogInformation("EmailBodyIntegrationEvent Attributes:");
    //     _logger.LogInformation($"  EmailBody: {@event.EmailBody}");
    //     _logger.LogInformation("--------------------------------------------------------------------------------------------------------------------");
    //     return Task.CompletedTask;
    // }
}