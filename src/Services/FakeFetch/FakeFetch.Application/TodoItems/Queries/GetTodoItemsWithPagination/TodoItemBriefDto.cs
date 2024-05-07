using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Queries.GetFakeFetchItemsWithPagination;

public class FakeFetchItemBriefDto
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<FakeFetchItem, FakeFetchItemBriefDto>();
        }
    }
}
