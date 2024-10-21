using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Send.Application.Services;

public class EmailCleanupService : BackgroundService, IEmailCleanupService
{
    private readonly IServiceProvider _serviceProvider;

    public EmailCleanupService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            await CleanupOldEmails(stoppingToken);
        }
    }

    public async Task CleanupOldEmails(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        var thirtyDaysAgo = DateTime.UtcNow.AddSeconds(-60);

        var oldEmailSnapshots = context.EmailSnapshots.Where(emailSnapshots =>
        emailSnapshots.SentDate < thirtyDaysAgo);
        context.EmailSnapshots.RemoveRange(oldEmailSnapshots);
        await context.SaveChangesAsync(stoppingToken);
    }
}