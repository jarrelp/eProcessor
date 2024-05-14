using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.Common.Models;

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
