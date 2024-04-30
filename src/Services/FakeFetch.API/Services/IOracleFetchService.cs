namespace Ecmanage.eProcessor.Services.FakeFetch.API.Services;

public interface IOracleFetchService
{
    Task<List<EmailQueueViewModel>> GetAllEmailQueuesAsync();
    Task<EmailQueueViewModel> GetEmailQueueByIdAsync(int id);
    Task AddEmailQueueAsync(EmailQueue emailQueue);
    Task UpdateEmailQueueAsync(EmailQueue emailQueue);
    Task DeleteEmailQueueAsync(int id);
}
