﻿using System.Reflection;
using Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.Behaviours;
using Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<LoginIntegrationEventHandler>();
        services.AddScoped<OverdueIntegrationEventHandler>();
        services.AddScoped<ReportIntegrationEventHandler>();
        services.AddScoped<UserIntegrationEventHandler>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        });

        return services;
    }
}
