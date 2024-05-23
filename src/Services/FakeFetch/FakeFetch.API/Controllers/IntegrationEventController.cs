using Dapr;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EventHandling;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Controllers;

public class IntegrationEventController : ApiControllerBase
{
    private const string DAPR_PUBSUB_NAME = "eprocessor-pubsub";

    [HttpPost("SendEmailAttempt")]
    [Topic(DAPR_PUBSUB_NAME, nameof(SendEmailAttemptIntegrationEvent))]
    public Task HandleAsync(
        SendEmailAttemptIntegrationEvent @event,
        [FromServices] SendEmailAttemptIntegrationEventHandler handler, CancellationToken cancellationToken)
        => handler.Handle(@event, cancellationToken);

    [HttpPost("EmailIsSend")]
    [Topic(DAPR_PUBSUB_NAME, nameof(EmailIsSendIntegrationEvent))]
    public Task HandleAsync(
        EmailIsSendIntegrationEvent @event,
        [FromServices] EmailIsSendIntegrationEventHandler handler, CancellationToken cancellationToken)
        => handler.Handle(@event, cancellationToken);

    [HttpPost("AllRetriesFailed")]
    [Topic(DAPR_PUBSUB_NAME, nameof(AllRetriesFailedIntegrationEvent))]
    public Task HandleAsync(
        AllRetriesFailedIntegrationEvent @event,
        [FromServices] AllRetriesFailedIntegrationEventHandler handler, CancellationToken cancellationToken)
        => handler.Handle(@event, cancellationToken);
}
