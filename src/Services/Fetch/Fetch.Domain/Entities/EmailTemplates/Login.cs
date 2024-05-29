using System.Xml.Serialization;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

[XmlRoot("login")]
public class Login
{
    [XmlElement("fullname")]
    public string FullName { get; set; } = string.Empty;

    [XmlElement("environment")]
    public string Environment { get; set; } = string.Empty;

    [XmlElement("ipaddress")]
    public string IpAddress { get; set; } = string.Empty;

    [XmlElement("date")]
    public string Date { get; set; } = string.Empty;

    [XmlElement("time")]
    public string Time { get; set; } = string.Empty;
}