using System.Xml.Serialization;

[XmlRoot("EmailQueues")]
public class EmailQueues
{
    [XmlElement("EmailQueue")]
    public List<EmailQueue> Items { get; set; }
}