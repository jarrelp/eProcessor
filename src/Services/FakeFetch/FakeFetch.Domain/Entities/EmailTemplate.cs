using System.ComponentModel.DataAnnotations;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

public abstract class EmailTemplate : BaseAuditableEntity
{
  public EmailTemplate()
  {
  }

  public EmailQueueItem EmailQueueItem { get; set; } = null!;
}
