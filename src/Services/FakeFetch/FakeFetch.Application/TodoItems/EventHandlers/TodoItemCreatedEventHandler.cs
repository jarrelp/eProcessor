using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.EventHandlers;

public class FakeFetchItemCreatedEventHandler : INotificationHandler<FakeFetchItemCreatedEvent>
{
    private readonly ILogger<FakeFetchItemCreatedEventHandler> _logger;

    public FakeFetchItemCreatedEventHandler(ILogger<FakeFetchItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(FakeFetchItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("FakeFetchApi Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
