using System.Xml.Serialization;

namespace Models
{
    [XmlRoot("EmailQueues")]
    public class EmailQueues
    {
        [XmlElement("EmailQueue")]
        public List<EmailQueue> EmailQueueList { get; set; }
    }
}