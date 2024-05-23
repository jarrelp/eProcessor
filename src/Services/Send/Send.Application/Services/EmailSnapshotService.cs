using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;

namespace Send.Application.Services;

public class EmailSnapshotService : IEmailSnapshotService
{
    private readonly IApplicationDbContext _context;

    public EmailSnapshotService(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task SaveEmailSnapshotAsync(EmailSnapshot emailSnapshot, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(emailSnapshot);

        _context.EmailSnapshots.Add(emailSnapshot);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
