﻿using Ecmanage.eProcessor.Services.Fetch.API.Domain.Entities;

namespace Ecmanage.eProcessor.Services.Fetch.API.Application.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, LookupDto>();
            CreateMap<TodoItem, LookupDto>();
        }
    }
}
