namespace Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent integrationEvent);
}
