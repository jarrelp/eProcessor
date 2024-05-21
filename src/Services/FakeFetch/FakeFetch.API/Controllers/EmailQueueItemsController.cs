using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddLoginEmail;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddOverdueEmail;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddReportEmail;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddUserEmail;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SendAllEmailQueueItems;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SetSentValueToNotYetPickedUp;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetNonProcessedEmailQueueItemsItemsWithPagination;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Controllers;

public class EmailQueueItemsController : ApiControllerBase
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
  public async Task<Result> SendAllEmailQueueItems(SendAllEmailQueueItemsCommand command)
  {
    await Mediator.Send(command);

    return Result.Success();
  }

  [HttpPut("SendFirstFewEmailQueueItems")]
  public async Task<Result> SendFirstFewEmailQueueItems(SendFirstFewEmailQueueItemsCommand command)
  {
    await Mediator.Send(command);

    return Result.Success();
  }

  [HttpPut("SetSentValueToNotYetPickedUp")]
  public async Task<Result> SetSentValueToNotYetPickedUp(SetSentValueToNotYetPickedUpCommand command)
  {
    await Mediator.Send(command);

    return Result.Success();
  }

  [HttpPost("AddLoginEmail")]
  public async Task<Result> AddLoginEmail(AddLoginEmailCommand command)
  {
    await Mediator.Send(command);

    return Result.Success();
  }

  [HttpPost("AddOverdueEmail")]
  public async Task<Result> AddOverdueEmail(AddOverdueEmailCommand command)
  {
    await Mediator.Send(command);

    return Result.Success();
  }

  [HttpPost("AddReportEmail")]
  public async Task<Result> AddReportEmail(AddReportEmailCommand command)
  {
    await Mediator.Send(command);

    return Result.Success();
  }

  [HttpPost("AddUserEmail")]
  public async Task<Result> AddUserEmail(AddUserEmailCommand command)
  {
    await Mediator.Send(command);

    return Result.Success();
  }
}