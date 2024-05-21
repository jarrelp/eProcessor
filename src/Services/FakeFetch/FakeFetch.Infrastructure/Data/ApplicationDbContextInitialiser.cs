using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary
        if (!_context.EmailQueueItems.Any())
        {
            // var login1 = GenerateSeedData.GenerateLoginData1();
            // var login2 = GenerateSeedData.GenerateLoginData2();

            // var overdue1 = GenerateSeedData.GenerateOverdueData1();
            // var overdue2 = GenerateSeedData.GenerateOverdueData2();

            // var report1 = GenerateSeedData.GenerateReportData1();
            // var report2 = GenerateSeedData.GenerateReportData2();

            // var user1 = GenerateSeedData.GenerateUserData1();
            // var user2 = GenerateSeedData.GenerateUserData2();

            // _context.EmailQueueItems.AddRange(new EmailQueueItem("LOGIN", "en-US", "aangepast@email.adr", 14451, "Login Email for aangepast@email.adr", "Random Message", login1),
            //     new EmailQueueItem("LOGIN", "en-US", "dizzel@dizzel.dizz", 14451, "Login Email for dizzel@dizzel.dizz", "Random Message", login2),
            //     new EmailQueueItem("OVERDUE", "en-US", "aangepast@email.adr", 14451, "Login Email for aangepast@email.adr", "Random Message", overdue1),
            //     new EmailQueueItem("OVERDUE", "en-US", "dizzel@dizzel.dizz", 14451, "Login Email for dizzel@dizzel.dizz", "Random Message", overdue2),
            //     new EmailQueueItem("REPORT", "en-US", "aangepast@email.adr", 14451, "Report Email for aangepast@email.adr", "Random Message", report1),
            //     new EmailQueueItem("REPORT", "en-US", "dizzel@dizzel.dizz", 14451, "Report Email for dizzel@dizzel.dizz", "Random Message", report2),
            //     new EmailQueueItem("USER", "en-US", "aangepast@email.adr", 14451, "User Email for aangepast@email.adr", "Random Message", user1),
            //     new EmailQueueItem("USER", "en-US", "dizzel@dizzel.dizz", 14451, "User Email for dizzel@dizzel.dizz", "Random Message", user2));

            await _context.SaveChangesAsync();
        }
    }
}
