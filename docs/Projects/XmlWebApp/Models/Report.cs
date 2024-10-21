using System.Xml.Serialization;

public class Report : IXmlDataContent
{
    [XmlElement("portalname")]
    public string Portalname { get; set; }

    [XmlElement("reportname")]
    public string Reportname { get; set; }

    [XmlElement("url")]
    public string Url { get; set; }
}