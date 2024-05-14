namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

public class Overdue : XmlData
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string ProductNumber { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public string OrderCode { get; set; } = string.Empty;
    public string OrderDate { get; set; } = string.Empty;

    public string OverdueDate { get; set; } = string.Empty;

    public Overdue(string fullName, string email, string productNumber, string productName, string orderCode, string orderDate, string overdueDate)
    {
        FullName = fullName;
        Email = email;
        ProductNumber = productNumber;
        ProductName = productName;
        OrderCode = orderCode;
        OrderDate = orderDate;
        OverdueDate = overdueDate;
    }
}
