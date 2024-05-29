using System.Xml.Serialization;
using Models.Templates;

public class XmlData
{
    [XmlElement("login", typeof(Login))]
    [XmlElement("overdue", typeof(Overdue))]
    [XmlElement("report", typeof(Report))]
    [XmlElement("user", typeof(User))]
    public object Data { get; set; }
    public string OuterXml { get; internal set; }
}