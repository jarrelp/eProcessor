// using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;
// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

// namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SendAllEmailQueueItems;

// public record SendAllEmailQueueItemsCommand(int? EmailQueueId) : IRequest
// {
// }

// public class SendAllEmailQueueItemsCommandHandler : IRequestHandler<SendAllEmailQueueItemsCommand>
// {
//     private readonly IApplicationDbContext _context;
//     private readonly IEventBus _eventBus;

//     public SendAllEmailQueueItemsCommandHandler(IApplicationDbContext context, IEventBus eventBus)
//     {
//         _context = context;
//         _eventBus = eventBus;
//     }

//     public async Task Handle(SendAllEmailQueueItemsCommand request, CancellationToken cancellationToken)
//     {
//         // Declaratie van de query zonder initialisatie
//         IQueryable<EmailQueueItem> emailQueueItemsQuery;

//         // Check of EmailQueueId in de request aanwezig is
//         if (request.EmailQueueId != null)
//         {
//             // Haal het specifieke EmailQueueItem op
//             var emailQueueItem = await _context.EmailQueueItems
//                 .Include(e => e.XmlData)
//                 .FirstOrDefaultAsync(x => x.EmailQueueId == request.EmailQueueId, cancellationToken);

//             // Als het specifieke item niet wordt gevonden, gooi een uitzondering
//             if (emailQueueItem == null)
//             {
//                 throw new Exception("EmailQueueItem not found with the given EmailQueueId.");
//             }

//             // Maak een query met alleen het specifieke item
//             emailQueueItemsQuery = _context.EmailQueueItems
//                 .Where(x => x.EmailQueueId == request.EmailQueueId)
//                 .Include(e => e.XmlData)
//                 .OrderBy(x => x.Id);
//         }
//         else
//         {
//             // Maak een query met alle items die nog niet zijn verzonden
//             emailQueueItemsQuery = _context.EmailQueueItems
//                 .Where(x => x.Sent == 'N')
//                 .Include(e => e.XmlData)
//                 .OrderBy(x => x.Id);
//         }

//         // Voer de query uit en materialiseer de resultaten in een lijst
//         var emailQueueItems = await emailQueueItemsQuery.ToListAsync(cancellationToken);

//         // Verwerk elk EmailQueueItem in de lijst
//         foreach (var emailQueueItem in emailQueueItems)
//         {
//             if (emailQueueItem.XmlData != null)
//             {
//                 switch (emailQueueItem.XmlData)
//                 {
//                     case Login loginTemplate:
//                         var loginIntegrationEvent = new LoginIntegrationEvent(
//                             emailQueueItem.EmailQueueId,
//                             loginTemplate.Id, loginTemplate.FullName,
//                             loginTemplate.Environment, loginTemplate.Date,
//                             loginTemplate.Time, emailQueueItem.Email, emailQueueItem.Subject);
//                         await _eventBus.PublishAsync(loginIntegrationEvent);
//                         break;

//                     case Overdue overdueTemplate:
//                         var overdueIntegrationEvent = new OverdueIntegrationEvent(
//                             emailQueueItem.EmailQueueId,
//                             overdueTemplate.Id, overdueTemplate.FullName,
//                             overdueTemplate.Email, overdueTemplate.ProductNumber,
//                             overdueTemplate.ProductName, overdueTemplate.OrderCode,
//                             overdueTemplate.OrderDate, overdueTemplate.OverdueDate,
//                             emailQueueItem.Email, emailQueueItem.Subject);
//                         await _eventBus.PublishAsync(overdueIntegrationEvent);
//                         break;

//                     case Report reportTemplate:
//                         var reportIntegrationEvent = new ReportIntegrationEvent(
//                             emailQueueItem.EmailQueueId,
//                             reportTemplate.Id, reportTemplate.PortalName,
//                             reportTemplate.ReportName, reportTemplate.Url,
//                             emailQueueItem.Email, emailQueueItem.Subject);
//                         await _eventBus.PublishAsync(reportIntegrationEvent);
//                         break;

//                     case User userTemplate:
//                         var userIntegrationEvent = new UserIntegrationEvent(
//                             emailQueueItem.EmailQueueId,
//                             userTemplate.Id, userTemplate.ImageHeader,
//                             userTemplate.Email, userTemplate.FullName,
//                             userTemplate.UserName, userTemplate.Password,
//                             userTemplate.Company, userTemplate.Url,
//                             emailQueueItem.Email, emailQueueItem.Subject);
//                         await _eventBus.PublishAsync(userIntegrationEvent);
//                         break;
//                 }

//                 // Markeer het item als verzonden
//                 emailQueueItem.Sent = 'B';
//             }
//             else
//             {
//                 throw new Exception("Cannot publish events, XmlData is null!");
//             }
//         }

//         // Sla de wijzigingen op in de database
//         await _context.SaveChangesAsync(cancellationToken);
//     }
// }
