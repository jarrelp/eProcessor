using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SetSentValueToNotYetPickedUp;

public record SetSentValueToNotYetPickedUpCommand(int Id) : IRequest
{
}

public class SetSentValueToNotYetPickedUpCommandHandler : IRequestHandler<SetSentValueToNotYetPickedUpCommand>
{
    private readonly IApplicationDbContext _context;

    public SetSentValueToNotYetPickedUpCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(SetSentValueToNotYetPickedUpCommand request, CancellationToken cancellationToken)
    {
        var emailQueueItems = _context.EmailQueueItems
            .Include(e => e.XmlData)
            .OrderBy(x => x.Id);

        foreach (var item in emailQueueItems)
        {
            item.Sent = 'N';
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
