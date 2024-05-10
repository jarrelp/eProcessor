using System.ComponentModel.DataAnnotations;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

public class EmailQueueItem : BaseEntity
{
  public int EmailQueueId { get; set; }

  // public string Subject { get; set; }
  public int Attempts { get; set; } = 0;
  public char Sent { get; set; } = 'N';
  // public int CompanyId { get; set; }
  public string SendAt { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  // public string IsoLanguage { get; set; }
  public string XslName { get; set; } = string.Empty;

  // Soort Email
  // public string XmlData { get; set; } // xml data

  public int EmailTemplateId { get; set; }
  public EmailTemplate EmailTemplate { get; set; } = null!;

  public EmailQueueItem(int emailQueueId, string xslName, string email, EmailTemplate emailTemplate)
  {
    EmailQueueId = emailQueueId;
    XslName = xslName;
    Email = email;
    EmailTemplate = emailTemplate;
  }

  public EmailQueueItem()
  {
    // Lege constructor vereist door Entity Framework Core
  }
}

