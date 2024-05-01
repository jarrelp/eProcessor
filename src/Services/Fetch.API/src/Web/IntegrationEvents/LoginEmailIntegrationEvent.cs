namespace Ecmanage.eProcessor.Services.Fetch.API.Web.IntegrationEvents;

public record LoginEmailIntegrationEvent(int EmailId, string FullName, string Environment, string Date, string Time) : IntegrationEvent;
