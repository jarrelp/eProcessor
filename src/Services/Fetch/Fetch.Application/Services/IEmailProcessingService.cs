namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Services;

public interface IEmailProcessingService
{
    Task FetchAndPublishEmailsAsync(CancellationToken cancellationToken);
}