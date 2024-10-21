using Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.Models;
using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Models;
using Ecmanage.eProcessor.Services.Send.Send.Application.EmailSnapshots.Queries.GetEmailSnapshotsWithPagination;

namespace Ecmanage.eProcessor.Services.Send.Send.API.Controllers;

public class EmailSnapshotsController : ApiControllerBase
{
  [HttpGet("GetEmailSnapshotsWithPagination")]
  public async Task<ActionResult<PaginatedList<EmailSnapshotDto>>> GetEmailSnapshotsWithPagination
  ([FromQuery] GetEmailSnapshotsWithPaginationQuery query)
  {
    return await Mediator.Send(query);
  }
}