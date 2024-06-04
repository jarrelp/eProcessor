using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Helpers;

public class EmailQueueManager : IEmailQueueManager
{
    private int _pendingEmails = 0;
    private bool _isBusy = false;

    public void IncrementPendingEmailsAsync(int count)
    {
        _pendingEmails += count;
    }

    public bool DecrementPendingEmailsAsync()
    {
        _pendingEmails--;
        return _pendingEmails == 0;
    }

    public bool GetIsBusy()
    {
        return _isBusy;
    }

    public void SetIsBusy(bool value)
    {
        _isBusy = value;
    }
}