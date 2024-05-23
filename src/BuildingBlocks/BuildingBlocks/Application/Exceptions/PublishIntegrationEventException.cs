using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.Exceptions;

public class PublishIntegrationEventException : Exception
{
    private const string PubSubName = "eprocessor-pubsub";

    public PublishIntegrationEventException(IntegrationEvent integrationEvent) : base($"Cannot publish event {integrationEvent} to {PubSubName}.{integrationEvent.GetType().Name}.") { }
}
