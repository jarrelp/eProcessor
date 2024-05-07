// Only use in this file to avoid conflicts with Microsoft.Extensions.Logging
using Serilog;

namespace Ecmanage.eProcessor.Services.FakeFetch;

public static class ProgramExtensions
{
    private const string AppName = "FakeFetch API";

    public static void AddCustomConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddDaprSecretStore(
           "eprocessor-secretstore",
           new DaprClientBuilder().Build());
    }

    public static void AddCustomSerilog(this WebApplicationBuilder builder)
    {
        var seqServerUrl = builder.Configuration["SeqServerUrl"];

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .WriteTo.Console()
            .WriteTo.Seq(seqServerUrl!)
            .Enrich.WithProperty("ApplicationName", AppName)
            .CreateLogger();

        builder.Host.UseSerilog();
    }

    public static void AddCustomSwagger(this WebApplicationBuilder builder) =>
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{AppName}", Version = "v1" });
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    });

    public static void UseCustomSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{AppName} V1");
        });
    }

    public static void AddCustomHealthChecks(this WebApplicationBuilder builder) =>
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddDapr()
            .AddSqlite(
                builder.Configuration["ConnectionStrings:FakeFetchDB"]!,
                name: "FakeFetchDb-check",
                tags: new[] { "fakeFetchdb" });

    public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEventBus, DaprEventBus>();
    }
}
