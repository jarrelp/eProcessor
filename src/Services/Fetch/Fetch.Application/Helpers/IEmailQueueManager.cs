namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Helpers;

public interface IEmailQueueManager
{
    void IncrementPendingEmailsAsync(int count);
    bool DecrementPendingEmailsAsync();
    bool GetIsBusy();
    void SetIsBusy(bool value);
}