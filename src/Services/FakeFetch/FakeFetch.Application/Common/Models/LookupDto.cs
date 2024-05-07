using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<FakeFetchList, LookupDto>();
            CreateMap<FakeFetchItem, LookupDto>();
        }
    }
}
