using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Services;

public class EmailProcessingService : IEmailProcessingService
{
    private readonly IOracleDCDataProvider _context;
    private readonly IEventBus _eventBus;
    private readonly ILogger<EmailProcessingService> _logger;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IEmailQueueManager _emailQueueManager;
    private readonly int _batchSize;

    public EmailProcessingService(
        IOracleDCDataProvider context,
        IEventBus eventBus,
        IConfiguration configuration,
        IEmailQueueManager emailQueueManager,
        ILogger<EmailProcessingService> logger,
        IMapper mapper)
    {
        _context = context;
        _eventBus = eventBus;
        _logger = logger;
        _mapper = mapper;
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

        //! dit weghalen:
        await Task.CompletedTask;
        var emailQueueItems = _emailDataRepository.GetAll().Take(5).ToList();

        // Todo: gebruik IOracleDCDataProvider

        // var emailQueueItems = await _context.EmailQueueItems
        //     .Where(x => x.Sent == 'N')
        //     .Take(_batchSize)
        //     .OrderBy(e => e.EmailQueueId)
        //     .Include(e => e.XmlData)
        //     .ToListAsync(cancellationToken);

        // if (!emailQueueItems.Any())
        // {
        //     _logger.LogInformation("No email queue items found to process.");
        //     _emailQueueManager.SetIsBusy(false);
        //     return;
        // }

        // _emailQueueManager.IncrementPendingEmailsAsync(emailQueueItems.Count);

        // foreach (var emailQueueItem in emailQueueItems)
        // {
        //     if (emailQueueItem.XmlData == null)
        //     {
        //         _logger.LogError("Cannot publish events, XmlData is null!");
        //         continue;
        //     }

        //     var integrationEvent = _mapper.Map<IntegrationEvent>(emailQueueItem.XmlData);
        //     if (integrationEvent == null)
        //     {
        //         _logger.LogError("Unsupported XmlData type for integration event mapping.");
        //         continue;
        //     }

        //     try
        //     {
        //         await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        //         emailQueueItem.Sent = 'B';
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex, "Error publishing IntegrationEvent");
        //         _emailQueueManager.SetIsBusy(false);
        //         continue;
        //     }
        // }

        // await _context.SaveChangesAsync(cancellationToken);
    }
}