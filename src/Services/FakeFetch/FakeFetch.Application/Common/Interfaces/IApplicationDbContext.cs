using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<FakeFetchList> FakeFetchLists { get; }

    DbSet<FakeFetchItem> FakeFetchItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
