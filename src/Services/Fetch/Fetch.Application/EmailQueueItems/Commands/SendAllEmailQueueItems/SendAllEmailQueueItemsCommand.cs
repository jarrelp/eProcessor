// using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
// using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Commands.SendAllEmailQueueItems;

// public record SendAllEmailQueueItemsCommand() : IRequest;

// public class SendAllEmailQueueItemsCommandHandler : IRequestHandler<SendAllEmailQueueItemsCommand>
// {
//     private readonly IApplicationDbContext _context;
//     private readonly IEventBus _eventBus;
//     private readonly IMapper _mapper;

//     public SendAllEmailQueueItemsCommandHandler(IApplicationDbContext context, IEventBus eventBus, IMapper mapper)
//     {
//         _context = context;
//         _eventBus = eventBus;
//         _mapper = mapper;
//     }

//     public async Task Handle(SendAllEmailQueueItemsCommand request, CancellationToken cancellationToken)
//     {
//         var emailQueueItems = await _context.EmailQueueItems
//             .Where(x => x.Sent == 'N')
//             .Include(e => e.XmlData)
//             .OrderBy(x => x.Id)
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