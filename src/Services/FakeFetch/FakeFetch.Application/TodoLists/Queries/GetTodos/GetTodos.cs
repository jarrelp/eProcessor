using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Models;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Enums;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Queries.GetFakeFetchs;

public record GetFakeFetchsQuery : IRequest<FakeFetchsVm>;

public class GetFakeFetchsQueryHandler : IRequestHandler<GetFakeFetchsQuery, FakeFetchsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFakeFetchsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FakeFetchsVm> Handle(GetFakeFetchsQuery request, CancellationToken cancellationToken)
    {
        return new FakeFetchsVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new LookupDto { Id = (int)p, Title = p.ToString() })
                .ToList(),

            Lists = await _context.FakeFetchLists
                .AsNoTracking()
                .ProjectTo<FakeFetchListDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
