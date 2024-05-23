using System.Threading;
using Ecmanage.eProcessor.Services.Process.Process.Application.EventHandling;
using Ecmanage.eProcessor.Services.Process.Process.Domain.Events;

namespace Ecmanage.eProcessor.Services.Process.Process.API.Controllers;

public class IntegrationEventController : ApiControllerBase
{
    private const string DAPR_PUBSUB_NAME = "eprocessor-pubsub";

    [HttpPost("ProcessLoginEmail")]
    [Topic(DAPR_PUBSUB_NAME, nameof(LoginIntegrationEvent))]
    public Task HandleAsync(
        LoginIntegrationEvent @event,
        [FromServices] LoginIntegrationEventHandler handler, CancellationToken cancellationToken)
        => handler.Handle(@event, cancellationToken);

    [HttpPost("ProcessOverdueEmail")]
    [Topic(DAPR_PUBSUB_NAME, nameof(OverdueIntegrationEvent))]
    public Task HandleAsync(
        OverdueIntegrationEvent @event,
        [FromServices] OverdueIntegrationEventHandler handler, CancellationToken cancellationToken)
        => handler.Handle(@event, cancellationToken);

    [HttpPost("ProcessReportEmail")]
    [Topic(DAPR_PUBSUB_NAME, nameof(ReportIntegrationEvent))]
    public Task HandleAsync(
        ReportIntegrationEvent @event,
        [FromServices] ReportIntegrationEventHandler handler, CancellationToken cancellationToken)
        => handler.Handle(@event, cancellationToken);

    [HttpPost("ProcessUserEmail")]
    [Topic(DAPR_PUBSUB_NAME, nameof(UserIntegrationEvent))]
    public Task HandleAsync(
        UserIntegrationEvent @event,
        [FromServices] UserIntegrationEventHandler handler, CancellationToken cancellationToken)
        => handler.Handle(@event, cancellationToken);
}
