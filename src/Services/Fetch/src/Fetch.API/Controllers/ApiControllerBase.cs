using Ecmanage.eProcessor.Services.Fetch.API.Filters; //? weird

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.API.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
  private ISender? _mediator;

  protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}