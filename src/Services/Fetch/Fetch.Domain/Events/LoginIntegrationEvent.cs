using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;

public record LoginIntegrationEvent(int EmailId, string FullName, string Environment, string Date, string Time) : IntegrationEvent;
