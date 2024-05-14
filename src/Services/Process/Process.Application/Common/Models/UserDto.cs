using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

public class UserDto : BaseEmail
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
            CreateMap<UserIntegrationEvent, UserDto>().ReverseMap();
        }
    }
}
