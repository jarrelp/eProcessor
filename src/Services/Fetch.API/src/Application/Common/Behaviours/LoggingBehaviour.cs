using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Fetch.API.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation("FetchApi Request: {Name} {@Request}",
            requestName, request);

        await Task.CompletedTask;
    }
}
