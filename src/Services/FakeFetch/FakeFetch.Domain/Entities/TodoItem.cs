namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

public class FakeFetchItem : BaseAuditableEntity
{
    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value && !_done)
            {
                AddDomainEvent(new FakeFetchItemCompletedEvent(this));
            }

            _done = value;
        }
    }

    public FakeFetchList List { get; set; } = null!;
}
