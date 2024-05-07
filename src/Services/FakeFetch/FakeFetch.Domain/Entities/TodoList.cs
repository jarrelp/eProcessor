namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

public class FakeFetchList : BaseAuditableEntity
{
    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<FakeFetchItem> Items { get; private set; } = new List<FakeFetchItem>();
}
