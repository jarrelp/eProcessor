namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Helpers;

public interface IEmailQueueManager
{
    void IncrementPendingEmailsAsync(int count);
    bool DecrementPendingEmailsAsync();
    bool GetIsBusy();
    void SetIsBusy(bool value);
}