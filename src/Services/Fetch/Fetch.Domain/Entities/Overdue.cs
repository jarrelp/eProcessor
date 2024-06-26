namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;

public class Overdue : XmlData
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? ProductNumber { get; set; }
    public string? ProductName { get; set; }
    public string? OrderCode { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? OverdueDate { get; set; }
}
