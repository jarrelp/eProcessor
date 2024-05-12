using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;
using Ecmanage.eProcessor.Services.Send.Send.Application.Helpers;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;
using Microsoft.Extensions.Logging;
using Mjml.Net;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.EventHandling;

public class LoginIntegrationEventHandler : IIntegrationEventHandler<LoginIntegrationEvent>
{
    private readonly ILogger<LoginIntegrationEventHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public LoginIntegrationEventHandler(ILogger<LoginIntegrationEventHandler> logger, IMapper mapper, IEventBus eventBus)
    {
        _logger = logger;
        _mapper = mapper;
        _eventBus = eventBus;
    }

    public async Task Handle(LoginIntegrationEvent @event)
    {
        LoginDto loginDto = _mapper.Map<LoginDto>(@event);
        string emailBody = LoginTemplate.CreateEmailBody(loginDto);
        EmailBodyIntegrationEvent emailBodyIntegrationEvent = _mapper.Map<EmailBodyIntegrationEvent>(emailBody);

        await _eventBus.PublishAsync(emailBodyIntegrationEvent);
    }
}
