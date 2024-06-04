using System.Xml.Linq;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Mappings;

public class EmailQueueMappingProfile : Profile
{
  public EmailQueueMappingProfile()
  {
    CreateMap<XElement, XmlDataDto>().ConvertUsing<XmlDataConverter>();

    CreateMap<EmailQueueDto, LoginIntegrationEvent>()
        .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
        .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.XmlData is LoginDto loginDto ? loginDto.EmailId : 0))
        .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.XmlData is LoginDto loginDto ? loginDto.Fullname : string.Empty))
        .ForMember(dest => dest.Environment, opt => opt.MapFrom(src => src.XmlData is LoginDto loginDto ? loginDto.Environment : string.Empty))
        .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.XmlData is LoginDto loginDto ? loginDto.Date.ToString() : string.Empty))
        .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.XmlData is LoginDto loginDto ? loginDto.Time.ToString() : string.Empty))
        .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

    CreateMap<EmailQueueDto, OverdueIntegrationEvent>()
        .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
        .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.XmlData is OverdueDto overdueDto ? overdueDto.EmailId : 0))
        .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.XmlData is OverdueDto overdueDto ? overdueDto.Fullname : string.Empty))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.XmlData is OverdueDto overdueDto ? overdueDto.Email : string.Empty))
        .ForMember(dest => dest.ProductNumber, opt => opt.MapFrom(src => src.XmlData is OverdueDto overdueDto ? overdueDto.Productnr : string.Empty))
        .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.XmlData is OverdueDto overdueDto ? overdueDto.Productname : string.Empty))
        .ForMember(dest => dest.OrderCode, opt => opt.MapFrom(src => src.XmlData is OverdueDto overdueDto ? overdueDto.Ordercode : string.Empty))
        .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.XmlData is OverdueDto overdueDto ? overdueDto.Orderdate.ToString() : string.Empty))
        .ForMember(dest => dest.OverdueDate, opt => opt.MapFrom(src => src.XmlData is OverdueDto overdueDto ? overdueDto.Overduedate.ToString() : string.Empty))
        .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

    CreateMap<EmailQueueDto, ReportIntegrationEvent>()
        .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
        .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.XmlData is ReportDto reportDto ? reportDto.EmailId : 0))
        .ForMember(dest => dest.PortalName, opt => opt.MapFrom(src => src.XmlData is ReportDto reportDto ? reportDto.Portalname : string.Empty))
        .ForMember(dest => dest.ReportName, opt => opt.MapFrom(src => src.XmlData is ReportDto reportDto ? reportDto.Reportname : string.Empty))
        .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.XmlData is ReportDto reportDto ? reportDto.Url : string.Empty))
        .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));

    CreateMap<EmailQueueDto, UserIntegrationEvent>()
        .ForMember(dest => dest.EmailQueueId, opt => opt.MapFrom(src => src.EmailQueueId))
        .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.XmlData is UserDto userDto ? userDto.EmailId : 0))
        .ForMember(dest => dest.ImageHeader, opt => opt.MapFrom(src => src.XmlData is UserDto userDto ? userDto.ImageHeader : string.Empty))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.XmlData is UserDto userDto ? userDto.Email : string.Empty))
        .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.XmlData is UserDto userDto ? userDto.Fullname : string.Empty))
        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.XmlData is UserDto userDto ? userDto.Username : string.Empty))
        .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.XmlData is UserDto userDto ? userDto.Password : string.Empty))
        .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.XmlData is UserDto userDto ? userDto.Company : string.Empty))
        .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.XmlData is UserDto userDto ? userDto.Url : string.Empty))
        .ForMember(dest => dest.EmailTo, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject));
  }
}