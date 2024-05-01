using System.Reflection;
using Ecmanage.eProcessor.Services.Fetch.API.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecmanage.eProcessor.Services.Fetch.API.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
