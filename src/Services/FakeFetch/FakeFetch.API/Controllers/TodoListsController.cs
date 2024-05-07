using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Commands.CreateFakeFetchList;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Commands.DeleteFakeFetchList;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Commands.UpdateFakeFetchList;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Queries.GetFakeFetchs;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Controllers;

public class FakeFetchListsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<FakeFetchsVm>> Get()
    {
        return await Mediator.Send(new GetFakeFetchsQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateFakeFetchListCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, UpdateFakeFetchListCommand command)
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
        await Mediator.Send(new DeleteFakeFetchListCommand(id));

        return NoContent();
    }
}