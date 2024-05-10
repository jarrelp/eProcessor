// using Ecmanage.eProcessor.Services.Fetch.Fetch.API.Application.Common.Models;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.API.Application.FetchItems.Commands.CreateFetchItem;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.API.Application.FetchItems.Commands.DeleteFetchItem;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.API.Application.FetchItems.Commands.UpdateFetchItem;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.API.Application.FetchItems.Commands.UpdateFetchItemDetail;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.API.Application.FetchItems.Queries.GetFetchItemsWithPagination;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.API.Application.UseCases.ProcessEmailData;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.API.Web.Controllers;

// public class EmailController : ApiControllerBase
// {
//   [HttpGet]
//   public async Task<ActionResult<PaginatedList<FetchItemBriefDto>>> GetFetchItemsWithPagination([FromQuery] GetFetchItemsWithPaginationQuery query)
//   {
//     return await Mediator.Send(query);
//   }

//   [HttpPost]
//   public async Task<ActionResult<int>> Create(CreateFetchItemCommand command)
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