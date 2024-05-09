using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;
// using FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class EmailQueueItemDto
{
    public int Id { get; init; }
    public string? Email { get; init; }
    public string? XslName { get; set; }
    public int EmailTemplateId { get; set; }
    public object EmailTemplateDto { get; set; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EmailQueueItem, EmailQueueItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.XslName, opt => opt.MapFrom(src => src.XslName))
                .ForMember(dest => dest.EmailTemplateId, opt => opt.MapFrom(src => src.EmailTemplate.Id))
                .ForMember(dest => dest.EmailTemplateDto, opt => opt.MapFrom(src => src.EmailTemplate));
        }
    }
}
