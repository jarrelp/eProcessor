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

    public async Task Handle(LoginIntegrationEvent @event, CancellationToken cancellationToken)
    {
        LoginDto loginDto = _mapper.Map<LoginDto>(@event) ?? throw new Exception("Unsupported LoginIntegrationEvent type for LoginDto mapping.");
        string emailBody = LoginTemplate.CreateEmailBody(loginDto);

        var emailBodyDto = new EmailBodyDto()
        {
            EmailBody = emailBody,
            EmailQueueId = loginDto.EmailQueueId,
            EmailFrom = loginDto.EmailFrom,
            EmailTo = loginDto.EmailTo,
            Subject = loginDto.Subject
        };

        EmailBodyIntegrationEvent emailBodyIntegrationEvent = _mapper.Map<EmailBodyIntegrationEvent>(emailBodyDto) ?? throw new Exception("Unsupported EmailBodyDto type for EmailBodyIntegrationEvent mapping.");

        try
        {
            await _eventBus.PublishAsync(emailBodyIntegrationEvent, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception("Error publishing IntegrationEvent", ex);
        }
    }
}
