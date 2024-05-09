using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Models;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Controllers;

public class EmailQueueItemsController : ApiControllerBase
{
  [HttpGet]
  public async Task<ActionResult<PaginatedList<EmailQueueItemDto>>> GetFakeFetchItemsWithPagination([FromQuery] GetEmailQueueItemsWithPaginationQuery query)
  {
    return await Mediator.Send(query);
  }
}