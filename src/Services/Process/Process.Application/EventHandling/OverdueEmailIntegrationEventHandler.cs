using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;
using Ecmanage.eProcessor.Services.Process.Process.Application.Helpers;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;

public class OverdueIntegrationEventHandler : IIntegrationEventHandler<OverdueIntegrationEvent>
{
    private readonly ILogger<OverdueIntegrationEventHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public OverdueIntegrationEventHandler(ILogger<OverdueIntegrationEventHandler> logger, IMapper mapper, IEventBus eventBus)
    {
        _logger = logger;
        _mapper = mapper;
        _eventBus = eventBus;
    }

    public async Task Handle(OverdueIntegrationEvent @event)
    {
        OverdueDto overdueDto = _mapper.Map<OverdueDto>(@event);
        string emailBody = OverdueTemplate.CreateEmailBody(overdueDto);

        var emailBodyDto = new EmailBodyDto()
        {
            EmailBody = emailBody,
            EmailFrom = overdueDto.EmailFrom,
            EmailTo = overdueDto.EmailTo,
            Subject = overdueDto.Subject
        };

        EmailBodyIntegrationEvent emailBodyIntegrationEvent = _mapper.Map<EmailBodyIntegrationEvent>(emailBodyDto);

        await _eventBus.PublishAsync(emailBodyIntegrationEvent);
    }
}