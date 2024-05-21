using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;

public record SendFirstFewEmailQueueItemsCommand() : IRequest;

public class SendFirstFewEmailQueueItemsCommandHandler : IRequestHandler<SendFirstFewEmailQueueItemsCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IEventBus _eventBus;
    private readonly ILogger<SendFirstFewEmailQueueItemsCommandHandler> _logger;
    private int _batchSize;

    public SendFirstFewEmailQueueItemsCommandHandler(IApplicationDbContext context, IEventBus eventBus, IConfiguration configuration, ILogger<SendFirstFewEmailQueueItemsCommandHandler> logger)
    {
        _context = context;
        _eventBus = eventBus;
        _logger = logger;
        var batchSizeValue = configuration["EmailProcessing:BatchSize"];
        var iets = "iets";
        _logger.LogWarning("" + iets);
        if (int.TryParse(batchSizeValue, out var batchSize))
        {
            _logger.LogWarning("BatchSize is a valid integer.");
            _batchSize = batchSize;
        }
        else
        {
            _logger.LogError("BatchSize is not a valid integer.");
            // Voer een fallbackwaarde in als dit mislukt
            _batchSize = 3; // Of een andere standaardwaarde
        }
    }

    public async Task Handle(SendFirstFewEmailQueueItemsCommand request, CancellationToken cancellationToken)
    {
        IQueryable<EmailQueueItem> emailQueueItemsQuery;


        emailQueueItemsQuery = _context.EmailQueueItems
            .Where(x => x.Sent == 'N')
            .Take(_batchSize)
            .OrderBy(e => e.EmailQueueId)
            .Include(e => e.XmlData);

        if (!emailQueueItemsQuery.Any())
        {
            throw new Exception("EmailQueueItem not found with the given amount.");
        }

        var emailQueueItems = await emailQueueItemsQuery.ToListAsync(cancellationToken);

        foreach (var emailQueueItem in emailQueueItems)
        {
            if (emailQueueItem.XmlData != null)
            {
                switch (emailQueueItem.XmlData)
                {
                    case Login loginTemplate:
                        var loginIntegrationEvent = new LoginIntegrationEvent(
                            emailQueueItem.EmailQueueId,
                            loginTemplate.Id, loginTemplate.FullName,
                            loginTemplate.Environment, loginTemplate.Date,
                            loginTemplate.Time, emailQueueItem.Email, emailQueueItem.Subject);
                        await _eventBus.PublishAsync(loginIntegrationEvent);
                        break;

                    case Overdue overdueTemplate:
                        var overdueIntegrationEvent = new OverdueIntegrationEvent(
                            emailQueueItem.EmailQueueId,
                            overdueTemplate.Id, overdueTemplate.FullName,
                            overdueTemplate.Email, overdueTemplate.ProductNumber,
                            overdueTemplate.ProductName, overdueTemplate.OrderCode,
                            overdueTemplate.OrderDate, overdueTemplate.OverdueDate,
                            emailQueueItem.Email, emailQueueItem.Subject);
                        await _eventBus.PublishAsync(overdueIntegrationEvent);
                        break;

                    case Report reportTemplate:
                        var reportIntegrationEvent = new ReportIntegrationEvent(
                            emailQueueItem.EmailQueueId,
                            reportTemplate.Id, reportTemplate.PortalName,
                            reportTemplate.ReportName, reportTemplate.Url,
                            emailQueueItem.Email, emailQueueItem.Subject);
                        await _eventBus.PublishAsync(reportIntegrationEvent);
                        break;

                    case User userTemplate:
                        var userIntegrationEvent = new UserIntegrationEvent(
                            emailQueueItem.EmailQueueId,
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
                throw new Exception("Cannot publish events, XmlData is null!");
            }
        }

        // var list = new List<int>();

        // foreach (var item in emailQueueItems)
        // {
        //     list.Add(item.EmailQueueId);
        // }

        await _context.SaveChangesAsync(cancellationToken);
    }
}

// pakt 5 items uit emailqueue
// nadat alle 5 items zijn verzonden pak je weer opnieuw 5 items uit de emailqueue
// stop met dit proces als de 