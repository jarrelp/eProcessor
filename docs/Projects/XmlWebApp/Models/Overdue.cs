using System.Xml.Serialization;

public class Overdue : IXmlDataContent
{
    [XmlElement("fullname")]
    public string Fullname { get; set; }

    [XmlElement("email")]
    public string Email { get; set; }

    [XmlElement("productnr")]
    public string Productnr { get; set; }

    [XmlElement("productname")]
    public string Productname { get; set; }

    [XmlElement("ordercode")]
    public string Ordercode { get; set; }

    [XmlElement("orderdate")]
    public DateTime Orderdate { get; set; }

    [XmlElement("overduedate")]
    public DateTime Overduedate { get; set; }
}