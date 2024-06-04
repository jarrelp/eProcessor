using Ardalis.GuardClauses;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Helpers;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Services;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EventHandling;


public class EmailIsSendIntegrationEventHandler : IIntegrationEventHandler<EmailIsSendIntegrationEvent>
{
  private readonly ILogger<EmailIsSendIntegrationEventHandler> _logger;
  private readonly IOracleDCDataProvider _context;
  private readonly IEmailQueueManager _emailQueueManager;
  private readonly IEmailProcessingService _emailProcessingService;
  private readonly IConfiguration _configuration;
  private readonly int _timeout;

  public EmailIsSendIntegrationEventHandler(
      ILogger<EmailIsSendIntegrationEventHandler> logger,
      IOracleDCDataProvider context,
      IEmailQueueManager emailQueueManager,
      IEmailProcessingService emailProcessingService,
      IConfiguration configuration)
  {
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _context = context ?? throw new ArgumentNullException(nameof(context));
    _emailQueueManager = emailQueueManager ?? throw new ArgumentNullException(nameof(emailQueueManager));
    _emailProcessingService = emailProcessingService ?? throw new ArgumentNullException(nameof(emailProcessingService));
    _configuration = configuration;
    _timeout = int.TryParse(_configuration["EmailProcessing:Timeout"], out var timeout) ? timeout : 2;
  }

  public async Task Handle(EmailIsSendIntegrationEvent @event, CancellationToken cancellationToken)
  {
    //! dit weghalen:
    await Task.CompletedTask;

    // Todo: gebruik IOracleDCDataProvider
    // var emailQueueItem = await _context.EmailQueueItems.FirstOrDefaultAsync(x => x.EmailQueueId == @event.EmailQueueId, cancellationToken);

    // if (emailQueueItem == null)
    // {
    //   _logger.LogError($"EmailQueueItem with ID {@event.EmailQueueId} not found.");
    //   throw new NotFoundException(@event.EmailQueueId.ToString(), nameof(EmailQueueItem));
    // }

    // emailQueueItem.Sent = 'Y';
    // emailQueueItem.SendAt = @event.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");

    // try
    // {
    //   await _context.SaveChangesAsync(cancellationToken);
    //   _logger.LogInformation($"EmailQueueItem with ID {@event.EmailQueueId} marked as sent.");
    //   var isBatchComplete = _emailQueueManager.DecrementPendingEmailsAsync();
    //   if (isBatchComplete)
    //   {
    //     Thread.Sleep(_timeout);
    //     await _emailProcessingService.FetchAndPublishEmailsAsync(cancellationToken);
    //   }
    // }
    // catch (Exception ex)
    // {
    //   _logger.LogError(ex, "Error occurred while updating EmailQueueItem.");
    //   throw;
    // }
  }
}