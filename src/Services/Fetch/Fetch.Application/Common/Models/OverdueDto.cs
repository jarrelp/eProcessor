// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

// public class OverdueDto : XmlDataDto
// {
//     public string FullName { get; init; } = null!;
//     public string Email { get; init; } = null!;
//     public string ProductNumber { get; init; } = null!;
//     public string ProductName { get; init; } = null!;
//     public string OrderCode { get; init; } = null!;
//     public string OrderDate { get; init; } = null!;
//     public string OverdueDate { get; init; } = null!;

//     private class Mapping : Profile
//     {
//         public Mapping()
//         {
//             CreateMap<Overdue, OverdueDto>().ReverseMap();
//         }
//     }
// }

public class OverdueDto : XmlDataDto
{
  public string? Fullname { get; set; }
  public string? Email { get; set; }
  public string? Productnr { get; set; }
  public string? Productname { get; set; }
  public string? Ordercode { get; set; }
  public DateTime Orderdate { get; set; }
  public DateTime Overduedate { get; set; }
}