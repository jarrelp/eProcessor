using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class EmailQueueItemDto
{
    public int Id { get; init; }
    public int Attempts { get; init; }
    public char Sent { get; init; }
    public string? SendAt { get; init; }
    public string? Email { get; init; }
    public string? XslName { get; set; }
    public object XmlData { get; set; } = null!;

    public int EmailQueueId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EmailQueueItem, EmailQueueItemDto>()
            .ForMember(dest => dest.XmlData, opt => opt.MapFrom(src => src.EmailTemplate));
        }
    }
}
