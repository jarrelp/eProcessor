// using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
// using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Logging;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;

// public record SendFirstFewEmailQueueItemsCommand() : IRequest;

// public class SendFirstFewEmailQueueItemsCommandHandler : IRequestHandler<SendFirstFewEmailQueueItemsCommand>
// {
//     private readonly IApplicationDbContext _context;
//     private readonly IEventBus _eventBus;
//     private readonly ILogger<SendFirstFewEmailQueueItemsCommandHandler> _logger;
//     private readonly IConfiguration _configuration;
//     private readonly int _batchSize;
//     private readonly IMapper _mapper;

//     public SendFirstFewEmailQueueItemsCommandHandler(IApplicationDbContext context, IEventBus eventBus, IConfiguration configuration, ILogger<SendFirstFewEmailQueueItemsCommandHandler> logger, IMapper mapper)
//     {
//         _context = context;
//         _eventBus = eventBus;
//         _logger = logger;
//         _mapper = mapper;
//         _configuration = configuration;
//         _batchSize = int.TryParse(_configuration["EmailProcessing:BatchSize"], out var batchSize) ? batchSize : 2;
//     }

//     public async Task Handle(SendFirstFewEmailQueueItemsCommand request, CancellationToken cancellationToken)
//     {
//         var emailQueueItems = await _context.EmailQueueItems
//             .Where(x => x.Sent == 'N')
//             .Take(_batchSize)
//             .OrderBy(e => e.EmailQueueId)
//             .Include(e => e.XmlData)
//             .ToListAsync(cancellationToken);

//         if (emailQueueItems.Count == 0)
//         {
//             throw new Exception("EmailQueueItem not found with the given amount.");
//         }

//         foreach (var emailQueueItem in emailQueueItems)
//         {
//             if (emailQueueItem.XmlData == null)
//             {
//                 throw new Exception("Cannot publish events, XmlData is null!");
//             }

//             var integrationEvent = _mapper.Map<IntegrationEvent>(emailQueueItem.XmlData) ?? throw new Exception("Unsupported XmlData type for integration event mapping.");
//             try
//             {
//                 await _eventBus.PublishAsync(integrationEvent, cancellationToken);
//                 emailQueueItem.Sent = 'B';
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception("Error publishing IntegrationEvent", ex);
//             }
//         }

//         await _context.SaveChangesAsync(cancellationToken);
//     }
// }

// // pakt 5 items uit emailqueue
// // nadat alle 5 items zijn verzonden pak je weer opnieuw 5 items uit de emailqueue
// // stop met dit proces als de 