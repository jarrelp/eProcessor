using System.Xml.Serialization;

public class User : IXmlDataContent
{
    [XmlElement("email")]
    public string Email { get; set; }

    [XmlElement("fullname")]
    public string Fullname { get; set; }

    [XmlElement("username")]
    public string Username { get; set; }

    [XmlElement("password")]
    public string Password { get; set; }

    [XmlElement("company")]
    public string Company { get; set; }

    [XmlElement("url")]
    public string Url { get; set; }
}