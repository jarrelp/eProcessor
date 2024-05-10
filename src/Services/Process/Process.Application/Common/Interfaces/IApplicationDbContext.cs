using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<EmailQueueItem> EmailQueueItems { get; }
    DbSet<Login> Logins { get; }
    DbSet<Overdue> Overdues { get; }
    DbSet<Report> Reports { get; }
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
