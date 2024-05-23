using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Controllers;

public class EmailQueueItemsController : ApiControllerBase
{
  [HttpPut("SendFirstFewEmailQueueItems")]
  public async Task<Result> SendFirstFewEmailQueueItems(SendFirstFewEmailQueueItemsCommand command)
  {
    await Mediator.Send(command);

    return Result.Success();
  }
}