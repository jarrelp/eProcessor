using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class EmailTemplateDto
{
  private class Mapping : Profile
  {
    public Mapping()
    {
      CreateMap<EmailTemplate, object>()
        .Include<Login, LoginDto>()
        .Include<Overdue, OverdueDto>()
        .Include<Report, ReportDto>()
        .Include<User, UserDto>();
    }
  }
}