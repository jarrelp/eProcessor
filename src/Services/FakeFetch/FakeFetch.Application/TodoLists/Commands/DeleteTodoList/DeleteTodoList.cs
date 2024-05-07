using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Commands.DeleteFakeFetchList;

public record DeleteFakeFetchListCommand(int Id) : IRequest;

public class DeleteFakeFetchListCommandHandler : IRequestHandler<DeleteFakeFetchListCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteFakeFetchListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteFakeFetchListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.FakeFetchLists
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.FakeFetchLists.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
