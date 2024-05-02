// using Ecmanage.eProcessor.Services.Fetch.API.Application.Common.Models;
// using Ecmanage.eProcessor.Services.Fetch.API.Application.TodoItems.Commands.CreateTodoItem;
// using Ecmanage.eProcessor.Services.Fetch.API.Application.TodoItems.Commands.DeleteTodoItem;
// using Ecmanage.eProcessor.Services.Fetch.API.Application.TodoItems.Commands.UpdateTodoItem;
// using Ecmanage.eProcessor.Services.Fetch.API.Application.TodoItems.Commands.UpdateTodoItemDetail;
// using Ecmanage.eProcessor.Services.Fetch.API.Application.TodoItems.Queries.GetTodoItemsWithPagination;
// using Ecmanage.eProcessor.Services.Fetch.API.Application.UseCases.ProcessEmailData;

// namespace Ecmanage.eProcessor.Services.Fetch.API.Web.Controllers;

// public class EmailController : ApiControllerBase
// {
//   [HttpGet]
//   public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
//   {
//     return await Mediator.Send(query);
//   }

//   [HttpPost]
//   public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
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