namespace Ecmanage.eProcessor.Services.FakeFetch.API.ViewModel.EmailTemplates;

public class OverdueViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ProductNumber { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string OrderCode { get; set; } = string.Empty;
    public string OrderDate { get; set; } = string.Empty;
    public string OverdueDate { get; set; } = string.Empty;
}
