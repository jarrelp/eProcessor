using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;
using Microsoft.Extensions.Logging;
using Mjml.Net;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;

public class LoginIntegrationEventHandler : IIntegrationEventHandler<LoginIntegrationEvent>
{
    private readonly ILogger<LoginIntegrationEventHandler> _logger;

    private readonly IMjmlRenderer _mjmlRenderer;

    public LoginIntegrationEventHandler(ILogger<LoginIntegrationEventHandler> logger, IMjmlRenderer mjmlRenderer)
    {
        _logger = logger;
        _mjmlRenderer = mjmlRenderer ?? throw new ArgumentNullException(nameof(mjmlRenderer));
    }

    // public Task Handle(LoginIntegrationEvent @event)
    // {
    //     _logger.LogInformation("Login Template Attributes:");
    //     _logger.LogInformation($"  FullName: {@event.FullName}");
    //     _logger.LogInformation($"  Environment: {@event.Environment}");
    //     _logger.LogInformation($"  Date: {@event.Date}");
    //     _logger.LogInformation($"  Time: {@event.Time}");
    //     return Task.CompletedTask;
    // }

    public Task Handle(LoginIntegrationEvent @event)
    {

        return Task.CompletedTask;
    }

    private string RenderEmail(string mjmlTemplatePath, object model)
    {
        var mjmlTemplate = File.ReadAllText(mjmlTemplatePath);
        var htmlContent = _mjmlRenderer.Render(mjmlTemplate, (MjmlOptions?)model);
        return htmlContent.ToString();
    }
}
