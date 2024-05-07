namespace Ecmanage.eProcessor.Services.Fetch.Fetch.API.IntegrationEvents;

public record LoginEmailIntegrationEvent(int EmailId, string FullName, string Environment, string Date, string Time) : IntegrationEvent;
