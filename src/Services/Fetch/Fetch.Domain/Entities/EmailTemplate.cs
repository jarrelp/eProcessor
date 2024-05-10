using System.ComponentModel.DataAnnotations;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;

public abstract class EmailTemplate : BaseEntity
{
  public EmailTemplate()
  {
  }

  public EmailQueueItem EmailQueueItem { get; set; } = null!;
}
