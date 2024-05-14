using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;
using Ecmanage.eProcessor.Services.Process.Process.Application.Helpers;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;

public class ReportIntegrationEventHandler : IIntegrationEventHandler<ReportIntegrationEvent>
{
    private readonly ILogger<ReportIntegrationEventHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public ReportIntegrationEventHandler(ILogger<ReportIntegrationEventHandler> logger, IMapper mapper, IEventBus eventBus)
    {
        _logger = logger;
        _mapper = mapper;
        _eventBus = eventBus;
    }

    public async Task Handle(ReportIntegrationEvent @event)
    {
        ReportDto reportDto = _mapper.Map<ReportDto>(@event);
        string emailBody = ReportTemplate.CreateEmailBody(reportDto);

        var emailBodyDto = new EmailBodyDto()
        {
            EmailBody = emailBody,
            EmailFrom = reportDto.EmailFrom,
            EmailTo = reportDto.EmailTo,
            Subject = reportDto.Subject
        };

        EmailBodyIntegrationEvent emailBodyIntegrationEvent = _mapper.Map<EmailBodyIntegrationEvent>(emailBodyDto);

        await _eventBus.PublishAsync(emailBodyIntegrationEvent);
    }
}