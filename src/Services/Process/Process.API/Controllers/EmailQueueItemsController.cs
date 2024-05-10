using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;
using Ecmanage.eProcessor.Services.Process.Process.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

namespace Ecmanage.eProcessor.Services.Process.Process.API.Controllers;

public class EmailQueueItemsController : ApiControllerBase
{
  [HttpGet]
  public async Task<ActionResult<EmailBodyDto>> GetFakeFetchItemsWithPagination([FromQuery] GetEmailQueueItemsWithPaginationQuery query)
  {
    return await Mediator.Send(query);
  }
}