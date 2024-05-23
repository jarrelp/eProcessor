using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.Common.Models;

public class EmailSnapshotDto : BaseEmailDto
{
    public string EmailBody { get; set; } = null!;
    public DateTime SentDate { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EmailSnapshot, EmailSnapshotDto>()
                .ForMember(dest => dest.EmailBody, opt => opt.MapFrom(src => src.Body));
            //.ForMember(dest => dest.EmailBody, opt => opt.Ignore());
        }
    }
}
