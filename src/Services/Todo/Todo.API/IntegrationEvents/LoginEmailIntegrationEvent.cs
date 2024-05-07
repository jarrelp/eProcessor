namespace Ecmanage.eProcessor.Services.Todo.Todo.API.IntegrationEvents;

public record LoginEmailIntegrationEvent(int EmailId, string FullName, string Environment, string Date, string Time) : IntegrationEvent;
