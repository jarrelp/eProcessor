using System.Xml.Serialization;

public class XmlData
{
    [XmlElement("login", Type = typeof(Login))]
    [XmlElement("overdue", Type = typeof(Overdue))]
    [XmlElement("report", Type = typeof(Report))]
    [XmlElement("user", Type = typeof(User))]
    public IXmlDataContent Data { get; set; }
}

// using System.Xml;
// using System.Xml.Serialization;

// public class XmlData
// {
//     [XmlAnyElement]
//     public XmlElement[] Elements { get; set; }
// }