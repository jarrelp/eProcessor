using System.Xml.Serialization;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

[XmlRoot("user")]
public class User
{
    [XmlElement("email")]
    public string Email { get; set; } = string.Empty;

    [XmlElement("fullname")]
    public string FullName { get; set; } = string.Empty;

    [XmlElement("username")]
    public string Username { get; set; } = string.Empty;

    [XmlElement("password")]
    public string Password { get; set; } = string.Empty;

    [XmlElement("company")]
    public string Company { get; set; } = string.Empty;

    [XmlElement("url")]
    public string Url { get; set; } = string.Empty;
}
