using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using Models;
using Models.Templates;

public class EmailQueueProfile : Profile
{
    public EmailQueueProfile()
    {
        CreateMap<EmailQueue, EmailQueueDto>();
        // .ForMember(dest => dest.XmlData, opt => opt.MapFrom(src => src.XmlData == null ? null : src.XmlData));
    }
    // public EmailQueueProfile()
    // {
    //     CreateMap<EmailQueue, EmailQueueDto>()
    //         .ForMember(dest => dest.XmlData, opt => opt.MapFrom(src => src.XmlData == null ? null : DeserializeXmlData(src.XmlData)));
    // }

    // private object DeserializeXmlData(string xmlData)
    // {
    //     if (xmlData == null)
    //         return null;

    //     var serializer = new XmlSerializer(xmlData.GetType());
    //     using (var reader = new StringReader(xmlData))
    //     {
    //         return serializer.Deserialize(reader);
    //     }
    // }

    // public EmailQueueProfile()
    // {
    //     CreateMap<EmailQueue, EmailQueueDto>()
    //         .ForMember(dest => dest.XmlData, opt => opt.MapFrom(src => MapXmlData(src.XmlData)));
    // }

    // private object MapXmlData(object xmlData)
    // {
    //     if (xmlData == null || xmlData == null)
    //         return null;

    //     var serializer = new XmlSerializer(xmlData.GetType());

    //     using (var stringWriter = new StringWriter())
    //     {
    //         using (var xmlTextWriter = XmlWriter.Create(stringWriter))
    //         {
    //             xmlData.WriteTo(xmlTextWriter);
    //             xmlTextWriter.Flush();
    //             string xmlString = stringWriter.GetStringBuilder().ToString();
    //             using (var reader = new StringReader(xmlString))
    //             {
    //                 return serializer.Deserialize(reader);
    //             }
    //         }
    //     }
    // }

    // public EmailQueueProfile()
    // {
    //     CreateMap<EmailQueue, EmailQueueDto>();
    //     // .ForMember(dest => dest.XmlData, opt => opt.MapFrom(src => MapXmlData(src.XmlData)));
    // }

    // private object MapXmlData(object xmlData)
    // {
    //     if (xmlData == null)
    //         return null;

    //     string xmlString = xmlData.ToString();

    //     // Deserialiseer de XML-gegevens naar het juiste type object op basis van de inhoud van de XmlData
    //     using (StringReader reader = new StringReader(xmlString))
    //     {
    //         using (XmlReader xmlReader = XmlReader.Create(reader))
    //         {
    //             // Zoek het root element om het type XML-object te identificeren
    //             xmlReader.MoveToContent();
    //             string rootElement = xmlReader.LocalName;

    //             // Deserialiseer naar het juiste type op basis van het root element
    //             switch (rootElement)
    //             {
    //                 case "login":
    //                     return DeserializeXml<LoginDto>(xmlString);
    //                 case "overdue":
    //                     return DeserializeXml<OverdueDto>(xmlString);
    //                 case "report":
    //                     return DeserializeXml<ReportDto>(xmlString);
    //                 case "user":
    //                     return DeserializeXml<UserDto>(xmlString);
    //                 default:
    //                     throw new InvalidOperationException("Unknown XmlData type.");
    //             }
    //         }
    //     }
    // }

    // private T DeserializeXml<T>(string xmlData) where T : class
    // {
    //     var serializer = new XmlSerializer(typeof(T));
    //     using (var reader = new StringReader(xmlData))
    //     {
    //         return serializer.Deserialize(reader) as T;
    //     }
    // }

    // public EmailQueueProfile()
    // {
    //     CreateMap<EmailQueue, EmailQueueDto>()
    //         .ForMember(dest => dest.XmlData, opt => opt.MapFrom(src => MapXmlData(src.XmlData)));
    //     CreateMap<Login, LoginDto>();
    //     CreateMap<Overdue, OverdueDto>();
    //     CreateMap<Report, ReportDto>();
    //     CreateMap<User, UserDto>();
    // }

    // private object MapXmlData(XmlData xmlData)
    // {
    //     var config = new MapperConfiguration(cfg =>
    // {
    //     cfg.AddProfile<EmailQueueProfile>();
    // });

    //     var mapper = config.CreateMapper();

    //     if (xmlData == null || xmlData.Data == null)
    //         return null;

    //     switch (xmlData.Data)
    //     {
    //         case Login loginData:
    //             return mapper.Map<LoginDto>(loginData);
    //         case Overdue overdueData:
    //             return mapper.Map<OverdueDto>(overdueData);
    //         case Report reportData:
    //             return mapper.Map<ReportDto>(reportData);
    //         case User userData:
    //             return mapper.Map<UserDto>(userData);
    //         default:
    //             throw new InvalidOperationException("Unknown XmlData type.");
    //     }
    // }

    // public EmailQueueProfile()
    // {
    //     CreateMap<EmailQueue, EmailQueueDto>()
    //         .ForMember(dest => dest.XmlData, opt => opt.MapFrom(src => src.XmlData.Data));
    //     CreateMap<Login, LoginDto>();
    //     CreateMap<Overdue, OverdueDto>();
    //     CreateMap<Report, ReportDto>();
    //     CreateMap<User, UserDto>();
    // }

    // private object MapXmlData(string xmlData)
    // {
    //     if (string.IsNullOrWhiteSpace(xmlData))
    //         return null;

    //     // Deserialiseer de XML-gegevens naar het juiste type object op basis van de inhoud van de XmlData
    //     using (StringReader reader = new StringReader(xmlData))
    //     {
    //         using (XmlReader xmlReader = XmlReader.Create(reader))
    //         {
    //             // Zoek het root element om het type XML-object te identificeren
    //             xmlReader.MoveToContent();
    //             string rootElement = xmlReader.LocalName;

    //             // Deserialiseer naar het juiste type op basis van het root element
    //             switch (rootElement)
    //             {
    //                 case "login":
    //                     return DeserializeXml<Login>(xmlData);
    //                 case "overdue":
    //                     return DeserializeXml<Overdue>(xmlData);
    //                 case "report":
    //                     return DeserializeXml<Report>(xmlData);
    //                 case "user":
    //                     return DeserializeXml<User>(xmlData);
    //                 default:
    //                     throw new InvalidOperationException("Unknown XmlData type.");
    //             }
    //         }
    //     }
    // }

    // private T DeserializeXml<T>(string xmlData) where T : class
    // {
    //     var serializer = new XmlSerializer(typeof(T));
    //     using (var reader = new StringReader(xmlData))
    //     {
    //         return serializer.Deserialize(reader) as T;
    //     }
    // }
}