using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;
using Ecmanage.eProcessor.Services.Process.Process.Application.Helpers;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;

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

        var emailBodyDto = new EmailBodyDto()
        {
            EmailBody = emailBody,
            EmailFrom = loginDto.EmailFrom,
            EmailTo = loginDto.EmailTo,
            Subject = loginDto.Subject
        };

        EmailBodyIntegrationEvent emailBodyIntegrationEvent = _mapper.Map<EmailBodyIntegrationEvent>(emailBodyDto);

        await _eventBus.PublishAsync(emailBodyIntegrationEvent);
    }
}
