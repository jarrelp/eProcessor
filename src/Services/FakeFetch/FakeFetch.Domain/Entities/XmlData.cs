namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

public abstract class XmlData : BaseEntity
{
  public XmlData()
  {
  }

  public EmailQueueItem EmailQueueItem { get; set; } = null!;
}
