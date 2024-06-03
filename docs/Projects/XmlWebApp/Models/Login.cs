using System.Xml.Serialization;

public class Login : IXmlDataContent
{
    [XmlElement("fullname")]
    public string Fullname { get; set; }

    [XmlElement("environment")]
    public string Environment { get; set; }

    [XmlElement("ipaddress")]
    public string Ipaddress { get; set; }

    [XmlElement("date")]
    public DateTime Date { get; set; }

    [XmlElement("time")]
    public TimeSpan Time { get; set; }
}