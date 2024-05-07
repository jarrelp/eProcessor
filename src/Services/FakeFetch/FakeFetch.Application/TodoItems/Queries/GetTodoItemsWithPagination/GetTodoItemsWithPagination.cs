using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Queries.GetFakeFetchItemsWithPagination;

public record GetFakeFetchItemsWithPaginationQuery : IRequest<PaginatedList<FakeFetchItemBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetFakeFetchItemsWithPaginationQueryHandler : IRequestHandler<GetFakeFetchItemsWithPaginationQuery, PaginatedList<FakeFetchItemBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFakeFetchItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<FakeFetchItemBriefDto>> Handle(GetFakeFetchItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.FakeFetchItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<FakeFetchItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
