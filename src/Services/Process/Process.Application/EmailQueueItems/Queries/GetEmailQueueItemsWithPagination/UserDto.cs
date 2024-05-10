using Ecmanage.eProcessor.Services.Process.Process.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class UserDto : EmailTemplateDto
{
    public string ImageHeader { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string FullName { get; init; } = null!;
    public string UserName { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Company { get; init; } = null!;
    public string Url { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
