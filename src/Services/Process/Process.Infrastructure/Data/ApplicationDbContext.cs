using System.Reflection;
using Ecmanage.eProcessor.Services.Process.Process.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;
using Microsoft.EntityFrameworkCore;

namespace Ecmanage.eProcessor.Services.Process.Process.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<EmailQueueItem> EmailQueueItems => Set<EmailQueueItem>();
    public DbSet<Login> Logins => Set<Login>();
    public DbSet<Overdue> Overdues => Set<Overdue>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
