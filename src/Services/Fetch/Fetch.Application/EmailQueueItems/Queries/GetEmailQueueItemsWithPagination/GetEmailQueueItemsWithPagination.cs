using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public record GetEmailQueueItemsWithPaginationQuery : IRequest<PaginatedList<EmailQueueItemDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetEmailQueueItemsWithPaginationQueryHandler : IRequestHandler<GetEmailQueueItemsWithPaginationQuery, PaginatedList<EmailQueueItemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public GetEmailQueueItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper, IEventBus eventBus)
    {
        _context = context;
        _mapper = mapper;
        _eventBus = eventBus;
    }

    public async Task<PaginatedList<EmailQueueItemDto>> Handle(GetEmailQueueItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var emailQueueItems = _context.EmailQueueItems
            .Include(e => e.EmailTemplate)
            .OrderBy(x => x.Id);

        foreach (var emailQueueItem in emailQueueItems)
        {
            if (emailQueueItem.EmailTemplate != null)
            {
                switch (emailQueueItem.EmailTemplate)
                {
                    case Login loginTemplate:
                        var loginIntegrationEvent =
                        new LoginIntegrationEvent(
                            loginTemplate.Id, loginTemplate.FullName,
                            loginTemplate.Environment, loginTemplate.Date,
                            loginTemplate.Time);
                        await _eventBus.PublishAsync(loginIntegrationEvent);
                        break;
                    case Overdue overdueTemplate:
                        var overdueIntegrationEvent =
                        new OverdueIntegrationEvent(
                            overdueTemplate.Id, overdueTemplate.FullName,
                            overdueTemplate.Email, overdueTemplate.ProductNumber,
                            overdueTemplate.ProductName, overdueTemplate.OrderCode,
                            overdueTemplate.OrderDate, overdueTemplate.OverdueDate);
                        await _eventBus.PublishAsync(overdueIntegrationEvent);
                        break;
                    case Report reportTemplate:
                        var reportIntegrationEvent =
                        new ReportIntegrationEvent(
                            reportTemplate.Id, reportTemplate.PortalName,
                            reportTemplate.ReportName, reportTemplate.Url);
                        await _eventBus.PublishAsync(reportIntegrationEvent);
                        break;
                    case User userTemplate:
                        var userIntegrationEvent =
                        new UserIntegrationEvent(
                            userTemplate.Id, userTemplate.ImageHeader,
                            userTemplate.Email, userTemplate.FullName,
                            userTemplate.UserName, userTemplate.Password,
                            userTemplate.Company, userTemplate.Url);
                        await _eventBus.PublishAsync(userIntegrationEvent);
                        break;
                }
            }
            else
            {
                throw new Exception("cannot publish event!");
            }
        }
        var ret = await emailQueueItems
            .ProjectTo<EmailQueueItemDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return ret;
    }
}
