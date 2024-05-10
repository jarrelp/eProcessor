using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class LoginDto : EmailTemplateDto
{
    public string FullName { get; init; } = null!;
    public string Environment { get; init; } = null!;
    public string Date { get; init; } = null!;
    public string Time { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Login, LoginDto>().ReverseMap();
        }
    }
}
