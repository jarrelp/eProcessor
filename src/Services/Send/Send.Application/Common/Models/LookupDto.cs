using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EmailSnapshot, LookupDto>();
        }
    }
}
