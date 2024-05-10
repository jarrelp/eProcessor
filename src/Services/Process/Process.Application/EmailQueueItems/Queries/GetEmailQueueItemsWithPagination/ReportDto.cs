using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class ReportDto : EmailTemplateDto
{
    public string PortalName { get; init; } = null!;
    public string ReportName { get; init; } = null!;
    public string Url { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Report, ReportDto>().ReverseMap();
        }
    }
}
