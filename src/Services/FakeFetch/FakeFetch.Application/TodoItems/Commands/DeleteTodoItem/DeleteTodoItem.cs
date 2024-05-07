using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Commands.DeleteFakeFetchItem;

public record DeleteFakeFetchItemCommand(int Id) : IRequest;

public class DeleteFakeFetchItemCommandHandler : IRequestHandler<DeleteFakeFetchItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteFakeFetchItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteFakeFetchItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.FakeFetchItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.FakeFetchItems.Remove(entity);

        entity.AddDomainEvent(new FakeFetchItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
