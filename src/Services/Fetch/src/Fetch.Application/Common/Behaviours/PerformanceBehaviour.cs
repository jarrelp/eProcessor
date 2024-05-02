﻿using System.Diagnostics;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;

    public PerformanceBehaviour(
        ILogger<TRequest> logger)
    {
        _timer = new Stopwatch();

        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogWarning("FetchApi Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                requestName, elapsedMilliseconds, request);
        }

        return response;
    }
}