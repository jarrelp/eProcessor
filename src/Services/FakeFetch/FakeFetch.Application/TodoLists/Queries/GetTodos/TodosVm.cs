using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Models;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Queries.GetFakeFetchs;

public class FakeFetchsVm
{
    public IReadOnlyCollection<LookupDto> PriorityLevels { get; init; } = Array.Empty<LookupDto>();

    public IReadOnlyCollection<FakeFetchListDto> Lists { get; init; } = Array.Empty<FakeFetchListDto>();
}
