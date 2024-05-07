namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

public class FakeFetchItemCompletedEvent : BaseEvent
{
    public FakeFetchItemCompletedEvent(FakeFetchItem item)
    {
        Item = item;
    }

    public FakeFetchItem Item { get; }
}
