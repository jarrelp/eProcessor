using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Helpers;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;

public record SendFirstFewEmailQueueItemsCommand() : IRequest;

public class SendFirstFewEmailQueueItemsCommandHandler : IRequestHandler<SendFirstFewEmailQueueItemsCommand>
{
    private readonly IEmailProcessingService _emailProcessingService;
    private readonly IEmailQueueManager _emailQueueManager;
    private readonly ILogger<SendFirstFewEmailQueueItemsCommandHandler> _logger;

    public SendFirstFewEmailQueueItemsCommandHandler(
        IEmailProcessingService emailProcessingService,
        IEmailQueueManager emailQueueManager,
        ILogger<SendFirstFewEmailQueueItemsCommandHandler> logger)
    {
        _emailProcessingService = emailProcessingService;
        _emailQueueManager = emailQueueManager;
        _logger = logger;
    }

    public async Task Handle(SendFirstFewEmailQueueItemsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (_emailQueueManager.GetIsBusy())
            {
                _logger.LogInformation("Email Processor System is busy!");
                return;
            }
            await _emailProcessingService.FetchAndPublishEmailsAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while processing email queue items.");
            throw;
        }

        return;
    }
}


// public class SendFirstFewEmailQueueItemsCommandHandler : IRequestHandler<SendFirstFewEmailQueueItemsCommand>
// {
//     private readonly IApplicationDbContext _context;
//     private readonly IEventBus _eventBus;
//     private readonly ILogger<SendFirstFewEmailQueueItemsCommandHandler> _logger;
//     private readonly IConfiguration _configuration;
//     private readonly IMediator _mediator;
//     private readonly int _batchSize;
//     private readonly IMapper _mapper;
//     private readonly IEmailQueueManager _emailQueueManager;

//     public SendFirstFewEmailQueueItemsCommandHandler(
//         IApplicationDbContext context,
//         IEventBus eventBus,
//         IConfiguration configuration,
//         IMediator mediator,
//         ILogger<SendFirstFewEmailQueueItemsCommandHandler> logger,
//         IMapper mapper,
//         IEmailQueueManager emailQueueManager)
//     {
//         _context = context;
//         _eventBus = eventBus;
//         _logger = logger;
//         _mapper = mapper;
//         _configuration = configuration;
//         _mediator = mediator;
//         _emailQueueManager = emailQueueManager;
//         _batchSize = int.TryParse(_configuration["EmailProcessing:BatchSize"], out var batchSize) ? batchSize : 2;
//     }

//     public async Task Handle(SendFirstFewEmailQueueItemsCommand request, CancellationToken cancellationToken)
//     {
//         var emailQueueItemsB = await _context.EmailQueueItems.AnyAsync(x => x.Sent == 'B', cancellationToken);
//         if (emailQueueItemsB)
//         {
//             _logger.LogInformation("Email Processor System is busy!");
//             return;
//         }

//         await FetchAndPublishEmailsAsync(cancellationToken);

//         return;
//     }

//     private async Task FetchAndPublishEmailsAsync(CancellationToken cancellationToken)
//     {
//         var emailQueueItems = await _context.EmailQueueItems
//             .Where(x => x.Sent == 'N')
//             .Take(_batchSize)
//             .OrderBy(e => e.EmailQueueId)
//             .Include(e => e.XmlData)
//             .ToListAsync(cancellationToken);

//         await _emailQueueManager.IncrementPendingEmailsAsync(emailQueueItems.Count);

//         if (emailQueueItems.Count == 0)
//         {
//             _logger.LogInformation("No email queue items found to process.");
//             return;
//         }

//         foreach (var emailQueueItem in emailQueueItems)
//         {
//             if (emailQueueItem.XmlData == null)
//             {
//                 _logger.LogError("Cannot publish events, XmlData is null!");
//                 continue;
//             }

//             var integrationEvent = _mapper.Map<IntegrationEvent>(emailQueueItem.XmlData);
//             if (integrationEvent == null)
//             {
//                 _logger.LogError("Unsupported XmlData type for integration event mapping.");
//                 continue;
//             }

//             try
//             {
//                 await _eventBus.PublishAsync(integrationEvent, cancellationToken);
//                 emailQueueItem.Sent = 'B';
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Error publishing IntegrationEvent");
//                 continue;
//             }
//         }

//         await _context.SaveChangesAsync(cancellationToken);
//     }
// }

// pakt 5 items uit emailqueue
// nadat alle 5 items zijn verzonden pak je weer opnieuw 5 items uit de emailqueue
// stop met dit proces als de 