using System.Xml.Linq;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Mappings;

public class EmailQueueItemProfile : Profile
{
    public EmailQueueItemProfile()
    {
        CreateMap<EmailQueueItem, LoginIntegrationEvent>()
            .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
            .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

        CreateMap<Login, LoginIntegrationEvent>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Environment, opt => opt.MapFrom(src => src.Environment))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString()))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.ToString()));

        CreateMap<EmailQueueItem, OverdueIntegrationEvent>()
            .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
            .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

        CreateMap<Overdue, OverdueIntegrationEvent>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.ProductNumber, opt => opt.MapFrom(src => src.ProductNumber))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.OrderCode, opt => opt.MapFrom(src => src.OrderCode))
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToString()))
            .ForMember(dest => dest.OverdueDate, opt => opt.MapFrom(src => src.OverdueDate.ToString()));

        CreateMap<EmailQueueItem, ReportIntegrationEvent>()
            .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
            .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

        CreateMap<Report, ReportIntegrationEvent>()
            .ForMember(dest => dest.PortalName, opt => opt.MapFrom(src => src.PortalName))
            .ForMember(dest => dest.ReportName, opt => opt.MapFrom(src => src.ReportName))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));

        CreateMap<EmailQueueItem, UserIntegrationEvent>()
            .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
            .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

        CreateMap<User, UserIntegrationEvent>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));
    }
}
