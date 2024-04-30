namespace Ecmanage.eProcessor.Services.FakeFetch.API.Model.EmailTemplates;

public class Report : EmailTemplate
{
    public string PortalName { get; set; }

    public string ReportName { get; set; }

    public string Url { get; set; }

    // Constructor
    public Report(int id, string portalName, string reportName, string url) : base(id)
    {
        Id = id;
        PortalName = portalName;
        ReportName = reportName;
        Url = url;
    }
}
