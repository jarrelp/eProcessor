using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Models;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Commands.CreateFakeFetchItem;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Commands.DeleteFakeFetchItem;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Commands.UpdateFakeFetchItem;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Commands.UpdateFakeFetchItemDetail;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Queries.GetFakeFetchItemsWithPagination;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Controllers;

public class FakeFetchItemsController : ApiControllerBase
{
  [HttpGet]
  public async Task<ActionResult<PaginatedList<FakeFetchItemBriefDto>>> GetFakeFetchItemsWithPagination([FromQuery] GetFakeFetchItemsWithPaginationQuery query)
  {
    return await Mediator.Send(query);
  }

  [HttpPost]
  public async Task<ActionResult<int>> Create(CreateFakeFetchItemCommand command)
  {
    return await Mediator.Send(command);
  }

  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesDefaultResponseType]
  public async Task<IActionResult> Update(int id, UpdateFakeFetchItemCommand command)
  {
    if (id != command.Id)
    {
      return BadRequest();
    }

    await Mediator.Send(command);

    return NoContent();
  }

  [HttpPut("[action]")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesDefaultResponseType]
  public async Task<IActionResult> UpdateItemDetails(int id, UpdateFakeFetchItemDetailCommand command)
  {
    if (id != command.Id)
    {
      return BadRequest();
    }

    await Mediator.Send(command);

    return NoContent();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesDefaultResponseType]
  public async Task<IActionResult> Delete(int id)
  {
    await Mediator.Send(new DeleteFakeFetchItemCommand(id));

    return NoContent();
  }
}