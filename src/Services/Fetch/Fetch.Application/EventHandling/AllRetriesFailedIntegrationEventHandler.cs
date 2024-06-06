using Ardalis.GuardClauses;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Repositories;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EventHandling;

public class AllRetriesFailedIntegrationEventHandler : IIntegrationEventHandler<AllRetriesFailedIntegrationEvent>
{
    private readonly ILogger<AllRetriesFailedIntegrationEventHandler> _logger;
    private readonly IEmailDataRepository _emailDataRepository;

    public AllRetriesFailedIntegrationEventHandler(ILogger<AllRetriesFailedIntegrationEventHandler> logger, IEmailDataRepository emailDataRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _emailDataRepository = emailDataRepository ?? throw new ArgumentNullException(nameof(emailDataRepository));
    }

    public async Task Handle(AllRetriesFailedIntegrationEvent @event, CancellationToken cancellationToken)
    {
        try
        {
            _emailDataRepository.SetSentToError(@event.EmailQueueId);
            _logger.LogInformation($"EmailQueueItem with ID {@event.EmailQueueId} sent updated to 'E'.");
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating EmailQueueItem.");
            throw;
        }
    }
}