﻿using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Login, LookupDto>();
            CreateMap<Overdue, LookupDto>();
            CreateMap<Report, LookupDto>();
            CreateMap<User, LookupDto>();
            CreateMap<EmailQueueItem, LookupDto>();
        }
    }
}
