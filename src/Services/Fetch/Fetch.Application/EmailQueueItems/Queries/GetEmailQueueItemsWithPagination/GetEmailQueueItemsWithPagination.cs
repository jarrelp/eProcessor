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
        return await _context.EmailQueueItems
            .Include(e => e.XmlData)
            .OrderBy(x => x.Id)
            .ProjectTo<EmailQueueItemDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
