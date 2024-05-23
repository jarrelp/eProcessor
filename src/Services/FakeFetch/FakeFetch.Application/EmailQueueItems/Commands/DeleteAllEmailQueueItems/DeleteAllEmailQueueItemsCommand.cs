using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.DeleteAllEmailQueueItems;

public record DeleteAllEmailQueueItemsCommand() : IRequest;

public class DeleteAllEmailQueueItemsCommandHandler : IRequestHandler<DeleteAllEmailQueueItemsCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAllEmailQueueItemsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAllEmailQueueItemsCommand request, CancellationToken cancellationToken)
    {
        var emailQueueItems = await _context.EmailQueueItems.ToListAsync(cancellationToken);

        _context.EmailQueueItems.RemoveRange(emailQueueItems);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
