using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;
using FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class OverdueDto : EmailTemplateDto
{
    public string FullName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string ProductNumber { get; init; } = null!;
    public string ProductName { get; init; } = null!;
    public string OrderCode { get; init; } = null!;
    public string OrderDate { get; init; } = null!;
    public string OverdueDate { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Overdue, OverdueDto>().ReverseMap();
        }
    }
}
