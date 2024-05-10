namespace Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;

public class Report : EmailTemplate
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
