using System.Xml.Serialization;

namespace Models.Templates
{
    [XmlRoot("report")]
    public class Report
    {
        public string PortalName { get; set; }

        public string ReportName { get; set; }

        public string Url { get; set; }
    }
}