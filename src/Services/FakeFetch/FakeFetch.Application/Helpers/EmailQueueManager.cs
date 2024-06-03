using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Services;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Helpers;

public class EmailQueueManager : IEmailQueueManager
{
    private int _pendingEmails = 0;

    public void IncrementPendingEmailsAsync(int count)
    {
        _pendingEmails += count;
    }

    public bool DecrementPendingEmailsAsync()
    {
        _pendingEmails--;
        return _pendingEmails == 0;
    }
}

// public class EmailQueueManager : IEmailQueueManager
// {
//     private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
//     private int _pendingEmails = 0;

//     public async Task IncrementPendingEmailsAsync(int count)
//     {
//         await _semaphore.WaitAsync();
//         try
//         {
//             Interlocked.Add(ref _pendingEmails, count);
//         }
//         finally
//         {
//             _semaphore.Release();
//         }
//     }

//     public async Task<bool> DecrementPendingEmailsAsync()
//     {
//         await _semaphore.WaitAsync();
//         try
//         {
//             Interlocked.Decrement(ref _pendingEmails);
//             return _pendingEmails == 0;
//         }
//         finally
//         {
//             _semaphore.Release();
//         }
//     }
// }
