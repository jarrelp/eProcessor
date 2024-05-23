using System.Threading;
using Ecmanage.eProcessor.Services.Send.Send.Application.EventHandling;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

namespace Ecmanage.eProcessor.Services.Send.Send.API.Controllers;

public class IntegrationEventController : ApiControllerBase
{
    private const string DAPR_PUBSUB_NAME = "eprocessor-pubsub";

    [HttpPost("SendEmail")]
    [Topic(DAPR_PUBSUB_NAME, nameof(EmailBodyIntegrationEvent))]
    public Task HandleAsync(
        EmailBodyIntegrationEvent @event,
        [FromServices] EmailBodyIntegrationEventHandler handler, CancellationToken cancellationToken)
        => handler.Handle(@event, cancellationToken);
}
