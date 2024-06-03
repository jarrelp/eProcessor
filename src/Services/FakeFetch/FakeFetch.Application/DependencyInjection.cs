using System.Reflection;
using Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.Behaviours;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EventHandling;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Helpers;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<AllRetriesFailedIntegrationEventHandler>();
        services.AddScoped<EmailIsSendIntegrationEventHandler>();
        services.AddScoped<SendEmailAttemptIntegrationEventHandler>();

        services.AddSingleton<IEmailQueueManager, EmailQueueManager>();

        services.AddScoped<IEmailProcessingService, EmailProcessingService>();

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
