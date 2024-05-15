using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SendAllEmailQueueItems;

public record SendAllEmailQueueItemsCommand(int Id) : IRequest
{
}

public class SendAllEmailQueueItemsCommandHandler : IRequestHandler<SendAllEmailQueueItemsCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IEventBus _eventBus;

    public SendAllEmailQueueItemsCommandHandler(IApplicationDbContext context, IEventBus eventBus)
    {
        _context = context;
        _eventBus = eventBus;
    }

    public async Task Handle(SendAllEmailQueueItemsCommand request, CancellationToken cancellationToken)
    {
        var emailQueueItems = _context.EmailQueueItems
            .Where(x => x.Sent == 'N')
            .Include(e => e.XmlData)
            .OrderBy(x => x.Id);

        foreach (var emailQueueItem in emailQueueItems)
        {
            if (emailQueueItem.XmlData != null)
            {
                switch (emailQueueItem.XmlData)
                {
                    case Login loginTemplate:
                        var loginIntegrationEvent =
                        new LoginIntegrationEvent(
                            loginTemplate.Id, loginTemplate.FullName,
                            loginTemplate.Environment, loginTemplate.Date,
                            loginTemplate.Time, emailQueueItem.Email, emailQueueItem.Subject);
                        await _eventBus.PublishAsync(loginIntegrationEvent);
                        break;
                    case Overdue overdueTemplate:
                        var overdueIntegrationEvent =
                        new OverdueIntegrationEvent(
                            overdueTemplate.Id, overdueTemplate.FullName,
                            overdueTemplate.Email, overdueTemplate.ProductNumber,
                            overdueTemplate.ProductName, overdueTemplate.OrderCode,
                            overdueTemplate.OrderDate, overdueTemplate.OverdueDate,
                            emailQueueItem.Email, emailQueueItem.Subject);
                        await _eventBus.PublishAsync(overdueIntegrationEvent);
                        break;
                    case Report reportTemplate:
                        var reportIntegrationEvent =
                        new ReportIntegrationEvent(
                            reportTemplate.Id, reportTemplate.PortalName,
                            reportTemplate.ReportName, reportTemplate.Url,
                            emailQueueItem.Email, emailQueueItem.Subject);
                        await _eventBus.PublishAsync(reportIntegrationEvent);
                        break;
                    case User userTemplate:
                        var userIntegrationEvent =
                        new UserIntegrationEvent(
                            userTemplate.Id, userTemplate.ImageHeader,
                            userTemplate.Email, userTemplate.FullName,
                            userTemplate.UserName, userTemplate.Password,
                            userTemplate.Company, userTemplate.Url,
                            emailQueueItem.Email, emailQueueItem.Subject);
                        await _eventBus.PublishAsync(userIntegrationEvent);
                        break;
                }
                emailQueueItem.Sent = 'B';
            }
            else
            {
                throw new Exception("cannot publish events!");
            }
        }

        // foreach (var item in emailQueueItems)
        // {
        //     item.Sent = 'B';
        // }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
