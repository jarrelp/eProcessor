using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EventHandling;

public class EmailIsSendIntegrationEventHandler : IIntegrationEventHandler<EmailIsSendIntegrationEvent>
{
    private readonly ILogger<EmailIsSendIntegrationEventHandler> _logger;
    private readonly IApplicationDbContext _context;

    public EmailIsSendIntegrationEventHandler(ILogger<EmailIsSendIntegrationEventHandler> logger, IApplicationDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(EmailIsSendIntegrationEvent @event)
    {
        _logger.LogInformation("--------------- EmailIsSendIntegrationEventHandler ---------------");

        var emailQueueItem = _context.EmailQueueItems.FirstOrDefault(x => x.EmailQueueId == @event.EmailQueueId);

        if (emailQueueItem == null)
        {
            _logger.LogError($"EmailQueueItem with ID {@event.EmailQueueId} not found.");
            throw new InvalidOperationException($"EmailQueueItem with ID {@event.EmailQueueId} not found.");
        }

        emailQueueItem.Sent = 'Y';
        emailQueueItem.SendAt = @event.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");

        try
        {
            await _context.SaveChangesAsync(CancellationToken.None);
            _logger.LogInformation($"EmailQueueItem with ID {@event.EmailQueueId} marked as sent.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating EmailQueueItem.");
            throw;
        }
    }
}