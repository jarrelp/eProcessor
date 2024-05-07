using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Queries.GetFakeFetchs;

public class FakeFetchItemDto
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }

    public int Priority { get; init; }

    public string? Note { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<FakeFetchItem, FakeFetchItemDto>().ForMember(d => d.Priority,
                opt => opt.MapFrom(s => (int)s.Priority));
        }
    }
}
