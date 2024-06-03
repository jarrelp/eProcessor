// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

// public class EmailQueueItemDto
// {
//     public int Id { get; init; }
//     public int EmailQueueId { get; set; }
//     public string XslName { get; set; } = string.Empty;
//     public string IsoLanguage { get; set; } = string.Empty;
//     public string Email { get; set; } = string.Empty;
//     public string SendAt { get; set; } = string.Empty;
//     public int CompanyId { get; set; }
//     public char Sent { get; set; }
//     public int Attempts { get; set; }
//     public string Subject { get; set; } = string.Empty;
//     public string Message { get; set; } = string.Empty;
//     public string Create_On { get; set; } = string.Empty;
//     public string Created_By { get; set; } = string.Empty;
//     public string Modified_On { get; set; } = string.Empty;
//     public string Modified_By { get; set; } = string.Empty;
//     public object XmlData { get; set; } = null!;

//     private class Mapping : Profile
//     {
//         public Mapping()
//         {
//             CreateMap<EmailQueueItem, EmailQueueItemDto>()
//             .ForMember(dest => dest.XmlData, opt => opt.MapFrom(src => src.XmlData));
//         }
//     }
// }
