// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

// public class ReportDto : XmlDataDto
// {
//     public string PortalName { get; init; } = null!;
//     public string ReportName { get; init; } = null!;
//     public string Url { get; init; } = null!;

//     private class Mapping : Profile
//     {
//         public Mapping()
//         {
//             CreateMap<Report, ReportDto>().ReverseMap();
//         }
//     }
// }

public class ReportDto : XmlDataDto
{
  public string? Portalname { get; set; }
  public string? Reportname { get; set; }
  public string? Url { get; set; }
}