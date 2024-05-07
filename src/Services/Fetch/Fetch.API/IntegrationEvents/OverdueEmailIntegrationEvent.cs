namespace Ecmanage.eProcessor.Services.Fetch.Fetch.API.IntegrationEvents;

public record OverdueEmailIntegrationEvent(int EmailId, string FullName, string Email, string ProductNumber, string ProductName, string OrderCode, string OrderDate, string OverdueDate) : IntegrationEvent;
