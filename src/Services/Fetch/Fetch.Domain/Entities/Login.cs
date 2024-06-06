namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;

public class Login : XmlData
{
    public string? FullName { get; set; }
    public string? Environment { get; set; }
    public string? IPAddress { get; set; }
    public DateTime? Date { get; set; }
    public TimeSpan? Time { get; set; }
}