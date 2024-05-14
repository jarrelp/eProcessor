// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.API.Controllers;

// public class IntegrationEventController : ApiControllerBase
// {
//     private const string DAPR_PUBSUB_NAME = "eprocessor-pubsub";

//     [HttpPost("ProcessLoginEmail")]
//     [Topic(DAPR_PUBSUB_NAME, nameof(LoginIntegrationEvent))]
//     public Task HandleAsync(
//         LoginIntegrationEvent @event,
//         [FromServices] LoginIntegrationEventHandler handler)
//         => handler.Handle(@event);

//     [HttpPost("ProcessOverdueEmail")]
//     [Topic(DAPR_PUBSUB_NAME, nameof(OverdueIntegrationEvent))]
//     public Task HandleAsync(
//         OverdueIntegrationEvent @event,
//         [FromServices] OverdueIntegrationEventHandler handler)
//         => handler.Handle(@event);

//     [HttpPost("ProcessReportEmail")]
//     [Topic(DAPR_PUBSUB_NAME, nameof(ReportIntegrationEvent))]
//     public Task HandleAsync(
//         ReportIntegrationEvent @event,
//         [FromServices] ReportIntegrationEventHandler handler)
//         => handler.Handle(@event);

//     [HttpPost("ProcessUserEmail")]
//     [Topic(DAPR_PUBSUB_NAME, nameof(UserIntegrationEvent))]
//     public Task HandleAsync(
//         UserIntegrationEvent @event,
//         [FromServices] UserIntegrationEventHandler handler)
//         => handler.Handle(@event);
// }
