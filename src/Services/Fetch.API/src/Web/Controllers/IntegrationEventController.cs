﻿using Ecmanage.eProcessor.Services.Fetch.API.Web.IntegrationEvents;
using Ecmanage.eProcessor.Services.Fetch.API.Web.IntegrationEvents.EventHandling;

namespace Ecmanage.eProcessor.Services.Fetch.API.Web.Controllers;

public class IntegrationEventController : ApiControllerBase
{
    private const string DAPR_PUBSUB_NAME = "pubsub";

    [HttpPost("ProcessLoginEmail")]
    [Topic(DAPR_PUBSUB_NAME, nameof(LoginEmailIntegrationEvent))]
    public Task HandleAsync(
        LoginEmailIntegrationEvent @event,
        [FromServices] LoginEmailIntegrationEventHandler handler)
        => handler.Handle(@event);

    [HttpPost("ProcessOverdueEmail")]
    [Topic(DAPR_PUBSUB_NAME, nameof(OverdueEmailIntegrationEvent))]
    public Task HandleAsync(
        OverdueEmailIntegrationEvent @event,
        [FromServices] OverdueEmailIntegrationEventHandler handler)
        => handler.Handle(@event);

    [HttpPost("ProcessReportEmail")]
    [Topic(DAPR_PUBSUB_NAME, nameof(ReportEmailIntegrationEvent))]
    public Task HandleAsync(
        ReportEmailIntegrationEvent @event,
        [FromServices] ReportEmailIntegrationEventHandler handler)
        => handler.Handle(@event);

    [HttpPost("ProcessUserEmail")]
    [Topic(DAPR_PUBSUB_NAME, nameof(UserEmailIntegrationEvent))]
    public Task HandleAsync(
        UserEmailIntegrationEvent @event,
        [FromServices] UserEmailIntegrationEventHandler handler)
        => handler.Handle(@event);
}
