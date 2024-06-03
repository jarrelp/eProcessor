using System.Xml.Serialization;

public class EmailQueue
{
    [XmlElement("EmailQueueId")]
    public int EmailQueueId { get; set; }

    [XmlElement("XmlData")]
    public XmlData XmlData { get; set; }

    [XmlElement("XslName")]
    public string XslName { get; set; }

    [XmlElement("IsoLanguage")]
    public string IsoLanguage { get; set; }

    [XmlElement("Email")]
    public string Email { get; set; }

    [XmlElement("SendAt")]
    public DateTime SendAt { get; set; }

    [XmlElement("CompanyId")]
    public int CompanyId { get; set; }

    [XmlElement("Sent")]
    public bool Sent { get; set; }

    [XmlElement("Attempts")]
    public int Attempts { get; set; }

    [XmlElement("Subject")]
    public string Subject { get; set; }

    [XmlElement("Message")]
    public string Message { get; set; }

    [XmlElement("Created_On")]
    public DateTime Created_On { get; set; }

    [XmlElement("Created_By")]
    public string Created_By { get; set; }

    [XmlElement("Modified_On")]
    public DateTime Modified_On { get; set; }

    [XmlElement("Modified_By")]
    public string Modified_By { get; set; }
}