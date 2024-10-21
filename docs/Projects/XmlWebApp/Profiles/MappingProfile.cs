using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmailQueue, EmailQueueDto>();
        CreateMap<XmlData, XmlDataDto>();
        // .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));
        CreateMap<Login, Login>();
        CreateMap<Overdue, Overdue>();
        CreateMap<Report, Report>();
        CreateMap<User, User>();
    }
}