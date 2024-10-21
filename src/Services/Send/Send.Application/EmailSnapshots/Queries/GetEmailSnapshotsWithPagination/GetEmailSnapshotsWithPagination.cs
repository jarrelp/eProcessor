using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Models;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.EmailSnapshots.Queries.GetEmailSnapshotsWithPagination;

public record GetEmailSnapshotsWithPaginationQuery
 : IRequest<PaginatedList<EmailSnapshotDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetEmailSnapshotsWithPaginationQueryHandler
 : IRequestHandler<GetEmailSnapshotsWithPaginationQuery, PaginatedList<EmailSnapshotDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEmailSnapshotsWithPaginationQueryHandler
    (IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<EmailSnapshotDto>> Handle
    (GetEmailSnapshotsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.EmailSnapshots
            .OrderBy(x => x.Id)
            .ProjectTo<EmailSnapshotDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
