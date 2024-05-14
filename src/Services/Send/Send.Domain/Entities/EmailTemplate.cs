namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;

public abstract class XmlData : BaseEntity
{
  public XmlData()
  {
  }

  public EmailQueueItem EmailQueueItem { get; set; } = null!;
}
