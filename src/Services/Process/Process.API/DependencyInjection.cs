using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<LoginIntegrationEventHandler>();
        services.AddScoped<OverdueIntegrationEventHandler>();
        services.AddScoped<ReportIntegrationEventHandler>();
        services.AddScoped<UserIntegrationEventHandler>();

        services.AddControllers();

        services.AddDaprClient();

        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddEndpointsApiExplorer();

        return services;
    }
}
