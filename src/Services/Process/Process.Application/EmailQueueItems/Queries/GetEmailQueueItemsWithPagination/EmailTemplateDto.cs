using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

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