using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

public class EmailBodyDto : BaseEmail
{
    public string EmailBody { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EmailBodyDto, EmailBodyIntegrationEvent>();
        }
    }
}
