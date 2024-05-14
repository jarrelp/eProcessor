using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

public class ReportDto : BaseEmail
{
    public string PortalName { get; init; } = null!;
    public string ReportName { get; init; } = null!;
    public string Url { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ReportIntegrationEvent, ReportDto>().ReverseMap();
        }
    }
}
