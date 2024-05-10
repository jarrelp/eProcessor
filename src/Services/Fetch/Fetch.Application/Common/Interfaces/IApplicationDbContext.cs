using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<EmailQueueItem> EmailQueueItems { get; }
    DbSet<Login> Logins { get; }
    DbSet<Overdue> Overdues { get; }
    DbSet<Report> Reports { get; }
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
