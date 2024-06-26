﻿using System.Reflection;
using Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.Behaviours;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Repositories;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EventHandling;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<AllRetriesFailedIntegrationEventHandler>();
        services.AddScoped<EmailIsSendIntegrationEventHandler>();
        services.AddScoped<SendEmailAttemptIntegrationEventHandler>();

        services.AddScoped<IEmailDataRepository, EmailDataRepository>();

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
