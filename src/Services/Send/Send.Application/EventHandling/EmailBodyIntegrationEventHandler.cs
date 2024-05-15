using Dapr.Client;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.EventHandling
{
    public class EmailBodyIntegrationEventHandler : IIntegrationEventHandler<EmailBodyIntegrationEvent>
    {
        private const string SendMailBinding = "sendmail";
        private const string CreateBindingOperation = "create";

        private readonly DaprClient _daprClient;
        private readonly ILogger<EmailBodyIntegrationEventHandler> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public EmailBodyIntegrationEventHandler(DaprClient daprClient, ILogger<EmailBodyIntegrationEventHandler> logger, IHttpClientFactory httpClientFactory)
        {
            _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task Handle(EmailBodyIntegrationEvent @event)
        {
            var retries = 0;

            var policy = Policy
                .HandleResult<HttpResponseMessage>(r => r == null || !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (result, timeSpan, retryCount, context) =>
                    {
                        retries++;
                        _logger.LogWarning($"Retry {retryCount} for email send operation due to {result.Result?.StatusCode.ToString() ?? "null response"}");
                    });

            HttpResponseMessage response = await policy.ExecuteAsync(() =>
            {
                try
                {
                    var iets = _daprClient.InvokeBindingAsync(
                        SendMailBinding,
                        CreateBindingOperation,
                        @event.EmailBody,
                        new Dictionary<string, string>
                        {
                            ["emailFrom"] = @event.EmailFrom,
                            ["emailTo"] = @event.EmailTo,
                            ["subject"] = @event.Subject
                        });
                    return (Task<HttpResponseMessage>)iets;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during InvokeBindingAsync");
                    throw;
                }
            });

            if (response != null && response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Email sent successfully after {retries} retries.");
            }
            else
            {
                _logger.LogError($"Failed to send email after {retries} retries. Status code: {response?.StatusCode.ToString() ?? "null response"}");
            }
        }
    }
}
