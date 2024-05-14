using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class XmlDataDto
{
  private class Mapping : Profile
  {
    public Mapping()
    {
      CreateMap<XmlData, object>()
        .Include<Login, LoginDto>()
        .Include<Overdue, OverdueDto>()
        .Include<Report, ReportDto>()
        .Include<User, UserDto>();
    }
  }
}