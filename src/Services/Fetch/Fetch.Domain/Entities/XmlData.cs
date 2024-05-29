namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;

public abstract class XmlData : BaseEntity
{
  public XmlData()
  {
  }

  public EmailQueueItem EmailQueueItem { get; set; } = null!;
}
