﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.Mappings;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
        => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
}