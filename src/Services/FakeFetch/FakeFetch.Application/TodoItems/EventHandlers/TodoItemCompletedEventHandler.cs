using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.EventHandlers;

public class FakeFetchItemCompletedEventHandler : INotificationHandler<FakeFetchItemCompletedEvent>
{
    private readonly ILogger<FakeFetchItemCompletedEventHandler> _logger;

    public FakeFetchItemCompletedEventHandler(ILogger<FakeFetchItemCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(FakeFetchItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("FakeFetchApi Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
