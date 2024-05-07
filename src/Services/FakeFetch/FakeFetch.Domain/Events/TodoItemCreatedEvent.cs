namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

public class FakeFetchItemCreatedEvent : BaseEvent
{
    public FakeFetchItemCreatedEvent(FakeFetchItem item)
    {
        Item = item;
    }

    public FakeFetchItem Item { get; }
}
