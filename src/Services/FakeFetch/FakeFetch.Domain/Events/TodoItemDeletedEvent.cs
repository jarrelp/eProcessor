namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

public class FakeFetchItemDeletedEvent : BaseEvent
{
    public FakeFetchItemDeletedEvent(FakeFetchItem item)
    {
        Item = item;
    }

    public FakeFetchItem Item { get; }
}
