using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Infrastructure.Data;

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
            var login1 = GenerateSeedData.GenerateLoginData1();
            var login2 = GenerateSeedData.GenerateLoginData2();

            var overdue1 = GenerateSeedData.GenerateOverdueData1();
            var overdue2 = GenerateSeedData.GenerateOverdueData2();

            var report1 = GenerateSeedData.GenerateReportData1();
            var report2 = GenerateSeedData.GenerateReportData2();

            var user1 = GenerateSeedData.GenerateUserData1();
            var user2 = GenerateSeedData.GenerateUserData2();

            _context.EmailQueueItems.AddRange(new EmailQueueItem(11502, "LOGIN", "aangepast@email.adr", login1),
                new EmailQueueItem(11503, "LOGIN", "dizzel@dizzel.dizz", login2),
                new EmailQueueItem(11504, "OVERDUE", "aangepast@email.adr", overdue1),
                new EmailQueueItem(11505, "OVERDUE", "dizzel@dizzel.dizz", overdue2),
                new EmailQueueItem(11506, "REPORT", "aangepast@email.adr", report1),
                new EmailQueueItem(11507, "REPORT", "dizzel@dizzel.dizz", report2),
                new EmailQueueItem(11508, "USER", "aangepast@email.adr", user1),
                new EmailQueueItem(11509, "USER", "dizzel@dizzel.dizz", user2));

            // var login1 = GenerateSeedData.GenerateLoginData1();
            // var login2 = GenerateSeedData.GenerateLoginData2();

            // _context.Logins.AddRange(
            //     login1, login2
            // );

            // var overdue1 = GenerateSeedData.GenerateOverdueData1();
            // var overdue2 = GenerateSeedData.GenerateOverdueData2();

            // _context.Overdues.AddRange(
            //     overdue1, overdue2
            // );

            // var report1 = GenerateSeedData.GenerateReportData1();
            // var report2 = GenerateSeedData.GenerateReportData2();

            // _context.Reports.AddRange(
            //     report1, report2
            // );

            // var user1 = GenerateSeedData.GenerateUserData1();
            // var user2 = GenerateSeedData.GenerateUserData2();

            // _context.Users.AddRange(
            //     user1, user2
            // );

            await _context.SaveChangesAsync();
        }
    }
}
