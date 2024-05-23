namespace Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;

public class EmailSnapshot : BaseEntity
{
  public int EmailQueueId { get; set; }
  public string EmailFrom { get; set; } = null!;
  public string EmailTo { get; set; } = null!;
  public string Subject { get; set; } = null!;
  public string Body { get; set; } = null!;
  public DateTime SentDate { get; set; }

  public EmailSnapshot() { }
}

