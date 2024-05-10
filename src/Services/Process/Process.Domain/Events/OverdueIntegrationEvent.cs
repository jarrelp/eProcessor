using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;

namespace Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

public record OverdueIntegrationEvent(int EmailId, string FullName, string Email, string ProductNumber, string ProductName, string OrderCode, string OrderDate, string OverdueDate) : IntegrationEvent;
