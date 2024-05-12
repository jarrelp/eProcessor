namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

public class OverdueDto
{
    public string FullName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string ProductNumber { get; init; } = null!;
    public string ProductName { get; init; } = null!;
    public string OrderCode { get; init; } = null!;
    public string OrderDate { get; init; } = null!;
    public string OverdueDate { get; init; } = null!;
}
