using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddLoginEmail;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddOverdueEmail;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddReportEmail;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddUserEmail;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.DeleteAllEmailQueueItems;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SendAllEmailQueueItems;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SetSentValueToNotYetPickedUp;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetNonProcessedEmailQueueItemsItemsWithPagination;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Controllers;

public class TestController : ApiControllerBase
{
    [HttpGet("GetEmailQueueItemsWithPagination")]
    public async Task<ActionResult<PaginatedList<EmailQueueItemDto>>> GetEmailQueueItemsWithPagination([FromQuery] GetEmailQueueItemsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("GetNonProcessedEmailQueueItemsItemsWithPagination")]
    public async Task<ActionResult<PaginatedList<EmailQueueItemDto>>> GetNonProcessedEmailQueueItemsItemsWithPagination([FromQuery] GetNonProcessedEmailQueueItemsItemsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPut("SendAllEmailQueueItems")]
    public async Task<IResult> SendAllEmailQueueItems(SendAllEmailQueueItemsCommand command)
    {
        await Mediator.Send(command);

        return Results.NoContent();
    }

    [HttpPut("SetSentValueToNotYetPickedUp")]
    public async Task<IResult> SetSentValueToNotYetPickedUp(SetSentValueToNotYetPickedUpCommand command)
    {
        await Mediator.Send(command);

        return Results.NoContent();
    }

    [HttpPost("AddLoginEmail")]
    public async Task<IResult> AddLoginEmail(AddLoginEmailCommand command)
    {
        await Mediator.Send(command);

        return Results.NoContent();
    }

    [HttpPost("AddOverdueEmail")]
    public async Task<IResult> AddOverdueEmail(AddOverdueEmailCommand command)
    {
        await Mediator.Send(command);

        return Results.NoContent();
    }

    [HttpPost("AddReportEmail")]
    public async Task<IResult> AddReportEmail(AddReportEmailCommand command)
    {
        await Mediator.Send(command);

        return Results.NoContent();
    }

    [HttpPost("AddUserEmail")]
    public async Task<IResult> AddUserEmail(AddUserEmailCommand command)
    {
        await Mediator.Send(command);

        return Results.NoContent();
    }

    [HttpDelete()]
    public async Task<IResult> Delete(DeleteAllEmailQueueItemsCommand command)
    {
        await Mediator.Send(command);

        return Results.NoContent();
    }
}