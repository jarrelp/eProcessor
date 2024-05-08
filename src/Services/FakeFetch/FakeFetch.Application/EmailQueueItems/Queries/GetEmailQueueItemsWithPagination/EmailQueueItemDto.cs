using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class EmailQueueItemDto
{
    public int Id { get; init; }
    public string? Email { get; init; }
    public string? XslName { get; set; }
    public int EmailTemplateId { get; set; }
    public EmailTemplate EmailTemplate { get; set; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EmailQueueItem, EmailQueueItemDto>();
        }
    }
}
