﻿using Ecmanage.eProcessor.Services.Fetch.API.Domain.Entities;

namespace Ecmanage.eProcessor.Services.Fetch.API.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
