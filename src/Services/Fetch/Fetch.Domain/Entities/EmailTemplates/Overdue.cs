using System.Xml.Serialization;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

[XmlRoot("overdue")]
public class Overdue
{
    [XmlElement("fullname")]
    public string FullName { get; set; } = string.Empty;

    [XmlElement("email")]
    public string Email { get; set; } = string.Empty;

    [XmlElement("productnr")]
    public string ProductNumber { get; set; } = string.Empty;

    [XmlElement("productname")]
    public string ProductName { get; set; } = string.Empty;

    [XmlElement("ordercode")]
    public string OrderCode { get; set; } = string.Empty;

    [XmlElement("orderdate")]
    public string OrderDate { get; set; } = string.Empty;

    [XmlElement("overduedate")]
    public string OverdueDate { get; set; } = string.Empty;
}
