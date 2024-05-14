namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Entities.EmailTemplates;

public class Report : XmlData
{
    public string PortalName { get; set; } = string.Empty;

    public string ReportName { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    // Constructor
    public Report(string portalName, string reportName, string url)
    {
        PortalName = portalName;
        ReportName = reportName;
        Url = url;
    }
}
