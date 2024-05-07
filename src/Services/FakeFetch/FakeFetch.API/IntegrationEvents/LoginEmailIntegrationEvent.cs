namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.IntegrationEvents;

public record LoginEmailIntegrationEvent(int EmailId, string FullName, string Environment, string Date, string Time) : IntegrationEvent;
