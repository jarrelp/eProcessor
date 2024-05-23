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

    public async Task Handle(OverdueIntegrationEvent @event, CancellationToken cancellationToken)
    {
        OverdueDto overdueDto = _mapper.Map<OverdueDto>(@event) ?? throw new Exception("Unsupported OverdueIntegrationEvent type for OverdueDto mapping."); ;
        string emailBody = OverdueTemplate.CreateEmailBody(overdueDto);

        var emailBodyDto = new EmailBodyDto()
        {
            EmailBody = emailBody,
            EmailQueueId = overdueDto.EmailQueueId,
            EmailFrom = overdueDto.EmailFrom,
            EmailTo = overdueDto.EmailTo,
            Subject = overdueDto.Subject
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