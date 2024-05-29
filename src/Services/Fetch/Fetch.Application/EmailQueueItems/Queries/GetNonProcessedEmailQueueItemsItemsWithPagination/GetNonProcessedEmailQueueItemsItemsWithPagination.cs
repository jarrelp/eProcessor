using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Queries.GetNonProcessedEmailQueueItemsItemsWithPagination;

public record GetNonProcessedEmailQueueItemsItemsWithPaginationQuery : IRequest<PaginatedList<EmailQueueItemDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetNonProcessedEmailQueueItemsItemsWithPaginationQueryHandler : IRequestHandler<GetNonProcessedEmailQueueItemsItemsWithPaginationQuery, PaginatedList<EmailQueueItemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetNonProcessedEmailQueueItemsItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<EmailQueueItemDto>> Handle(GetNonProcessedEmailQueueItemsItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.EmailQueueItems
            .Where(x => x.Sent == 'N')
            .Include(e => e.XmlData)
            .OrderBy(x => x.Id)
            .ProjectTo<EmailQueueItemDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}

