using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Queries.GetFakeFetchs;

public class FakeFetchListDto
{
    public FakeFetchListDto()
    {
        Items = Array.Empty<FakeFetchItemDto>();
    }

    public int Id { get; init; }

    public string? Title { get; init; }

    public string? Colour { get; init; }

    public IReadOnlyCollection<FakeFetchItemDto> Items { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<FakeFetchList, FakeFetchListDto>();
        }
    }
}
