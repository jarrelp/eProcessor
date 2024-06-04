// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

// public class UserDto : XmlDataDto
// {
//     public string ImageHeader { get; init; } = null!;
//     public string Email { get; init; } = null!;
//     public string FullName { get; init; } = null!;
//     public string UserName { get; init; } = null!;
//     public string Password { get; init; } = null!;
//     public string Company { get; init; } = null!;
//     public string Url { get; init; } = null!;

//     private class Mapping : Profile
//     {
//         public Mapping()
//         {
//             CreateMap<User, UserDto>().ReverseMap();
//         }
//     }
// }

public class UserDto : XmlDataDto
{
  public string? Email { get; set; }
  public string? Fullname { get; set; }
  public string? Username { get; set; }
  public string? Password { get; set; }
  public string? Company { get; set; }
  public string? Url { get; set; }
}