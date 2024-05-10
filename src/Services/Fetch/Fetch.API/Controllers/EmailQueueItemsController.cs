using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.API.Controllers;

public class EmailQueueItemsController : ApiControllerBase
{
  [HttpGet]
  public async Task<ActionResult<PaginatedList<EmailQueueItemDto>>> GetFetchItemsWithPagination([FromQuery] GetEmailQueueItemsWithPaginationQuery query)
  {
    return await Mediator.Send(query);
  }
}