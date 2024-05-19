using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

namespace Send.Application.Common.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmailBodyIntegrationEvent, EmailSnapshot>()
            .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.EmailBody))
            .ForMember(dest => dest.SentDate, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
