using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

public class LoginDto : XmlDataDto
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
