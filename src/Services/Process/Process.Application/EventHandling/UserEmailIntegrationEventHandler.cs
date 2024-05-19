using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;
using Ecmanage.eProcessor.Services.Process.Process.Application.Helpers;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;

public class UserIntegrationEventHandler : IIntegrationEventHandler<UserIntegrationEvent>
{
    private readonly ILogger<UserIntegrationEventHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public UserIntegrationEventHandler(ILogger<UserIntegrationEventHandler> logger, IMapper mapper, IEventBus eventBus)
    {
        _logger = logger;
        _mapper = mapper;
        _eventBus = eventBus;
    }

    public async Task Handle(UserIntegrationEvent @event)
    {
        UserDto userDto = _mapper.Map<UserDto>(@event);
        string emailBody = UserTemplate.CreateEmailBody(userDto);

        var emailBodyDto = new EmailBodyDto()
        {
            EmailBody = emailBody,
            EmailQueueId = userDto.EmailQueueId,
            EmailFrom = userDto.EmailFrom,
            EmailTo = userDto.EmailTo,
            Subject = userDto.Subject
        };

        EmailBodyIntegrationEvent emailBodyIntegrationEvent = _mapper.Map<EmailBodyIntegrationEvent>(emailBodyDto);

        await _eventBus.PublishAsync(emailBodyIntegrationEvent);
    }
}