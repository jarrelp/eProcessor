// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Application.Common.Models;
// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Application.FakeFetchItems.Commands.CreateFakeFetchItem;
// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Application.FakeFetchItems.Commands.DeleteFakeFetchItem;
// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Application.FakeFetchItems.Commands.UpdateFakeFetchItem;
// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Application.FakeFetchItems.Commands.UpdateFakeFetchItemDetail;
// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Application.FakeFetchItems.Queries.GetFakeFetchItemsWithPagination;
// using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Application.UseCases.ProcessEmailData;

// namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.API.Web.Controllers;

// public class EmailController : ApiControllerBase
// {
//   [HttpGet]
//   public async Task<ActionResult<PaginatedList<FakeFetchItemBriefDto>>> GetFakeFetchItemsWithPagination([FromQuery] GetFakeFetchItemsWithPaginationQuery query)
//   {
//     return await Mediator.Send(query);
//   }

//   [HttpPost]
//   public async Task<ActionResult<int>> Create(CreateFakeFetchItemCommand command)
//   {
//     return await Mediator.Send(command);
//   }

//   [Topic("pubsub", "oracledata", "deadletters", false)]
//   [HttpPost("process")]

//   public async Task<IActionResult> ProcessEmailDataAsync(IntegrationEvent @event)
//   {
//     if (!ModelState.IsValid)
//     {
//       return BadRequest(ModelState);
//     }

//     await _processEmailDataUseCase.ExecuteAsync(input);

//     return Ok();
//   }
// }