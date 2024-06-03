using System.Xml.Linq;
using AutoMapper;

public class XmlDataMappingProfile : Profile
{
    public XmlDataMappingProfile()
    {
        CreateMap<XElement, IXmlDataContent>()
            .ConvertUsing<XmlDataConverter>();
    }
}