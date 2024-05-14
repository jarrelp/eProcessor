namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

public record OverdueIntegrationEvent(int EmailId, string FullName, string Email, string ProductNumber, string ProductName, string OrderCode, string OrderDate, string OverdueDate, string EmailTo, string Subject) : BaseEmailIntegrationEvent(EmailTo, Subject);
