using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Commands.PurgeFakeFetchLists;

public record PurgeFakeFetchListsCommand : IRequest;

public class PurgeFakeFetchListsCommandHandler : IRequestHandler<PurgeFakeFetchListsCommand>
{
    private readonly IApplicationDbContext _context;

    public PurgeFakeFetchListsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(PurgeFakeFetchListsCommand request, CancellationToken cancellationToken)
    {
        _context.FakeFetchLists.RemoveRange(_context.FakeFetchLists);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
