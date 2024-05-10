using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

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