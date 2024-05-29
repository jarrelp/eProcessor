using Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Infrastructure.Interceptors;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:OracleTestDB"]!;
        // var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string not found.");

        services.AddScoped<IOracleDCDataProvider>(provider =>
        {
            return new OracleDCDataProvider(connectionString);
        });

        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
