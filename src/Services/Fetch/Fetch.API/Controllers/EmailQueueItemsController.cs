using Ecmanage.eProcessor.BuildingBlocks.EventBus.Events;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Repositories;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.API.Controllers;

public class EmailQueueItemsController : ApiControllerBase
{
  private readonly IEmailDataRepository _emailDataRepository;

  public EmailQueueItemsController(IEmailDataRepository emailDataRepository)
  {
    _emailDataRepository = emailDataRepository;
  }

  [HttpGet("IntegrationEvents")]
  public ActionResult<List<IntegrationEvent>> GetIntegrationEvents([FromQuery] int count = 5)
  {
    var integrationEvents = _emailDataRepository.GetIntegrationEvents(count);

    if (integrationEvents == null || integrationEvents.Count == 0)
    {
      return NoContent();
    }

    return Ok(integrationEvents);
  }

  [HttpGet("ProcessedEmails")]
  public ActionResult GetAllProcessed()
  {
    _emailDataRepository.GetAllProcessed();
    return Ok();
  }

  [HttpGet("NotPickedUpEmails")]
  public ActionResult GetAllNotPickedUp()
  {
    _emailDataRepository.GetAllNotPickedUp();
    return Ok();
  }

  [HttpPost("SetSentToNotPickedUp/{id}")]
  public ActionResult SetSentToNotPickedUp(int id)
  {
    _emailDataRepository.SetSentToNotPickedUp(id);
    return Ok();
  }

  [HttpPost("SetSentToProcessed/{id}")]
  public ActionResult SetSentToProcessed(int id)
  {
    _emailDataRepository.SetSentToProcessed(id);
    return Ok();
  }

  [HttpPost("SetAllSentToNotPickedUp")]
  public ActionResult SetAllSentToNotPickedUp()
  {
    _emailDataRepository.SetAllSentToNotPickedUp();
    return Ok();
  }

  [HttpPost("SetSentToIsBusy/{id}")]
  public ActionResult SetSentToIsBusy(int id)
  {
    _emailDataRepository.SetSentToIsBusy(id);
    return Ok();
  }

  [HttpPost("SetSentToError/{id}")]
  public ActionResult SetSentToError(int id)
  {
    _emailDataRepository.SetSentToError(id);
    return Ok();
  }

  [HttpPost("SetAttempt")]
  public ActionResult SetAttempt([FromQuery] int id, [FromQuery] int attempts)
  {
    try
    {
      _emailDataRepository.SetAttempts(id, attempts);
      return Ok(new { Message = "Attempts updated successfully", EmailQueueId = id, Attempts = attempts });
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { Message = "An error occurred while updating attempts", Details = ex.Message });
    }
  }

  [HttpDelete("DeleteAllEmailQueueItems")]
  public ActionResult DeleteAllEmailQueueItems()
  {
    _emailDataRepository.DeleteAllEmailQueueItems();
    return Ok();
  }

  [HttpPost("GenerateEmails/{amount}")]
  public ActionResult GenerateEmails(int amount)
  {
    _emailDataRepository.GenerateEmails(amount);
    return Ok();
  }

  [HttpGet("ColumnNames")]
  public async Task<ActionResult<List<string>>> GetColumnNamesAsync()
  {
    var columnNames = await _emailDataRepository.GetColumnNamesAsync();
    return Ok(columnNames);
  }
}