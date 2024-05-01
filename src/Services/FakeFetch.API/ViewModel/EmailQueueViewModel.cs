namespace Ecmanage.eProcessor.Services.FakeFetch.API.ViewModel;

public class EmailQueueViewModel
{
    public string Email { get; set; } = string.Empty;
    public string XslName { get; set; } = string.Empty;
    public int EmailQueueId { get; set; }
    public int EmailTemplateId { get; set; }
    public object EmailTemplate { get; set; } = string.Empty; // Dit kan worden vervangen door het specifieke ViewModel van de e-mailsjabloon, afhankelijk van de logica van je applicatie
}
