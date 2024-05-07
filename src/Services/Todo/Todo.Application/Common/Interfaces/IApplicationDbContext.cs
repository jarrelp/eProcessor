using Ecmanage.eProcessor.Services.Todo.Todo.Domain.Entities;

namespace Ecmanage.eProcessor.Services.Todo.Todo.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
