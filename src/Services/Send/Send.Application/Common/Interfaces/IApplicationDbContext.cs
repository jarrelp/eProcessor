using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<EmailSnapshot> EmailSnapshots { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
