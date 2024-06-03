// using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Mappings
// {
//     public class EmailQueueItemProfile : Profile
//     {
//         public EmailQueueItemProfile()
//         {
//             CreateMap<XmlData, IntegrationEvent>()
//                 .Include<Login, LoginIntegrationEvent>()
//                 .Include<Overdue, OverdueIntegrationEvent>()
//                 .Include<Report, ReportIntegrationEvent>()
//                 .Include<User, UserIntegrationEvent>();

//             CreateMap<Login, LoginIntegrationEvent>()
//                 .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueItem.EmailQueueId))
//                 .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.EmailQueueItem.Email))
//                 .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.EmailQueueItem.Subject));

//             CreateMap<Overdue, OverdueIntegrationEvent>()
//                 .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueItem.EmailQueueId))
//                 .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.EmailQueueItem.Email))
//                 .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.EmailQueueItem.Subject));

//             CreateMap<Report, ReportIntegrationEvent>()
//                 .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueItem.EmailQueueId))
//                 .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.EmailQueueItem.Email))
//                 .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.EmailQueueItem.Subject));

//             CreateMap<User, UserIntegrationEvent>()
//                 .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueItem.EmailQueueId))
//                 .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.EmailQueueItem.Email))
//                 .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.EmailQueueItem.Subject));
//         }
//     }
// }