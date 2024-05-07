namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.IntegrationEvents;

public record UserEmailIntegrationEvent(int EmailId, string ImageHeader, string Email, string FullName, string UserName, string Password, string Company, string Url) : IntegrationEvent;
