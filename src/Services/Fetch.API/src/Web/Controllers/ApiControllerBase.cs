using Ecmanage.eProcessor.Services.Fetch.API.API.Filters;

namespace Ecmanage.eProcessor.Services.Fetch.API.Web.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
  private ISender? _mediator;

  protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}