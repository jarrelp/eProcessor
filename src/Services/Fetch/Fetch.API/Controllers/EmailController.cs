using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.API.Controllers;

public class EmailController : ApiControllerBase
{
    [HttpPut("Work")]
    public async Task<Result> Work(SendFirstFewEmailQueueItemsCommand command)
    {
        await Mediator.Send(command);

        return Result.Success();
    }
}