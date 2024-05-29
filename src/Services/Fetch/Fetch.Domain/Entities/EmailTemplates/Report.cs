using System.Xml.Serialization;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

[XmlRoot("report")]
public class Report
{
    [XmlElement("portalname")]
    public string PortalName { get; set; } = string.Empty;

    [XmlElement("reportname")]
    public string ReportName { get; set; } = string.Empty;

    [XmlElement("url")]
    public string Url { get; set; } = string.Empty;
}
