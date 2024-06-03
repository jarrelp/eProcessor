// using System.Xml.Linq;
// using AutoMapper;

// public class EmailQueueMappingProfile : Profile
// {
//     private readonly IMapper _mapper;

//     public EmailQueueMappingProfile(IMapper mapper)
//     {
//         _mapper = mapper;

//         CreateMap<XElement, EmailQueue>()
//             .ForMember(dest => dest.XmlData, opt => opt.MapFrom(src => new XmlData { Data = _mapper.Map<IXmlDataContent>(src.Element("XmlData")) }));
//     }
// }