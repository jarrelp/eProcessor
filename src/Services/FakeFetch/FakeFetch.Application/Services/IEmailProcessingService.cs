namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Services;

public interface IEmailProcessingService
{
    Task FetchAndPublishEmailsAsync(CancellationToken cancellationToken);
}