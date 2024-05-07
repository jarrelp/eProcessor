using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.Behaviours;

public class LoggingBehaviour<TRequest>
    (ILogger<TRequest> logger)
    : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly ILogger _logger = logger;

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation("eProcessor Request: {Name} {@Request}",
                requestName, request);
        }, cancellationToken);
    }
}