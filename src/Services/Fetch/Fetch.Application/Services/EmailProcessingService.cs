using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Helpers;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Repositories;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Services;

public class EmailProcessingService : IEmailProcessingService
{
    private readonly IEmailDataRepository _emailDataRepository;
    private readonly IEventBus _eventBus;
    private readonly ILogger<EmailProcessingService> _logger;
    private readonly IConfiguration _configuration;
    private readonly IEmailQueueManager _emailQueueManager;
    private readonly int _batchSize;

    public EmailProcessingService(
        IEmailDataRepository emailDataRepository,
        IOracleDCDataProvider context,
        IEventBus eventBus,
        IConfiguration configuration,
        IEmailQueueManager emailQueueManager,
        ILogger<EmailProcessingService> logger)
    {
        _emailDataRepository = emailDataRepository;
        _eventBus = eventBus;
        _logger = logger;
        _configuration = configuration;
        _emailQueueManager = emailQueueManager;
        _batchSize = int.TryParse(_configuration["EmailProcessing:BatchSize"], out var batchSize) ? batchSize : 2;
    }

    public async Task FetchAndPublishEmailsAsync(CancellationToken cancellationToken)
    {
        if (!_emailQueueManager.GetIsBusy())
        {
            _emailQueueManager.SetIsBusy(true);
        }

        var integrationEvents = _emailDataRepository.GetIntegrationEvents(_batchSize); //? batchSize + 1?

        if (!integrationEvents.Any())
        {
            _logger.LogInformation("No email queue items found to process.");
            _emailQueueManager.SetIsBusy(false);
            return;
        }

        _emailQueueManager.IncrementPendingEmailsAsync(integrationEvents.Count);

        foreach (var integrationEvent in integrationEvents)
        {
            try
            {
                if (integrationEvent is LoginIntegrationEvent login)
                {
                    await _eventBus.PublishAsync(login, cancellationToken);
                    _emailDataRepository.SetSentToIsBusy(login.EmailQueueId);
                }
                else if (integrationEvent is OverdueIntegrationEvent overdue)
                {
                    await _eventBus.PublishAsync(overdue, cancellationToken);
                    _emailDataRepository.SetSentToIsBusy(overdue.EmailQueueId);
                }
                else if (integrationEvent is ReportIntegrationEvent report)
                {
                    await _eventBus.PublishAsync(report, cancellationToken);
                    _emailDataRepository.SetSentToIsBusy(report.EmailQueueId);
                }
                else if (integrationEvent is UserIntegrationEvent user)
                {
                    await _eventBus.PublishAsync(user, cancellationToken);
                    _emailDataRepository.SetSentToIsBusy(user.EmailQueueId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error publishing IntegrationEvent");
                _emailQueueManager.SetIsBusy(false);
                continue;
            }
        }
    }
}