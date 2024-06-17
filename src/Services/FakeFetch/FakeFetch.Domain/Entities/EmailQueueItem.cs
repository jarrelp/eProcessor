namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

public class EmailQueueItem : BaseEntity
{
  public int EmailQueueId { get; set; }
  public string XslName { get; set; } = string.Empty;
  public string IsoLanguage { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string SendAt { get; set; } = string.Empty;
  public int CompanyId { get; set; }
  public char Sent { get; set; } = 'N';
  public int Attempts { get; set; } = 0;
  public string Subject { get; set; } = string.Empty;
  public string Message { get; set; } = string.Empty;
  public string Create_On { get; set; } = string.Empty;
  public string Created_By { get; set; } = string.Empty;
  public string Modified_On { get; set; } = string.Empty;
  public string Modified_By { get; set; } = string.Empty;

  public int XmlDataId { get; set; }
  public XmlData XmlData { get; set; } = null!;

  public EmailQueueItem(string xslName, string isoLanguage, string email, int companyId, string subject, string message, XmlData xmlData)
  {
    XslName = xslName;
    IsoLanguage = isoLanguage;
    Email = email;
    CompanyId = companyId;
    Subject = subject;
    Message = message;
    Create_On = DateTime.Now.ToString();
    Created_By = "Email Processor System";
    XmlData = xmlData;
  }

  public EmailQueueItem()
  {

  }
}

