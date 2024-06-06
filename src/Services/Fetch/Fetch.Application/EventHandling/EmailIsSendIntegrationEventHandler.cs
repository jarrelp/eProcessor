using Ardalis.GuardClauses;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Helpers;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Repositories;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Services;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EventHandling;


public class EmailIsSendIntegrationEventHandler : IIntegrationEventHandler<EmailIsSendIntegrationEvent>
{
  private readonly ILogger<EmailIsSendIntegrationEventHandler> _logger;
  private readonly IEmailDataRepository _emailDataRepository;
  private readonly IEmailQueueManager _emailQueueManager;
  private readonly IEmailProcessingService _emailProcessingService;
  private readonly IConfiguration _configuration;
  private readonly int _timeout;

  public EmailIsSendIntegrationEventHandler(
      ILogger<EmailIsSendIntegrationEventHandler> logger,
      IEmailDataRepository emailDataRepository,
      IEmailQueueManager emailQueueManager,
      IEmailProcessingService emailProcessingService,
      IConfiguration configuration)
  {
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _emailDataRepository = emailDataRepository ?? throw new ArgumentNullException(nameof(emailDataRepository));
    _emailQueueManager = emailQueueManager ?? throw new ArgumentNullException(nameof(emailQueueManager));
    _emailProcessingService = emailProcessingService ?? throw new ArgumentNullException(nameof(emailProcessingService));
    _configuration = configuration;
    _timeout = int.TryParse(_configuration["EmailProcessing:Timeout"], out var timeout) ? timeout : 2;
  }

  public async Task Handle(EmailIsSendIntegrationEvent @event, CancellationToken cancellationToken)
  {
    try
    {
      _emailDataRepository.SetSentToProcessed(@event.EmailQueueId);
      _logger.LogInformation($"EmailQueueItem with ID {@event.EmailQueueId} marked as sent.");
      var isBatchComplete = _emailQueueManager.DecrementPendingEmailsAsync();
      if (isBatchComplete)
      {
        Thread.Sleep(_timeout);
        await _emailProcessingService.FetchAndPublishEmailsAsync(cancellationToken);
        await Task.CompletedTask;
      }
      await Task.CompletedTask;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error occurred while updating EmailQueueItem.");
      throw;
    }
  }
}