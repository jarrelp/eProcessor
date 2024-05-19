using Dapr.Client;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Models;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.EventHandling
{
    public class EmailBodyIntegrationEventHandler : IIntegrationEventHandler<EmailBodyIntegrationEvent>
    {
        private const string SendMailBinding = "sendmail";
        private const string CreateBindingOperation = "create";

        private int RetryCount = 0;

        private const int MaxRetryCount = 2;

        private static readonly Random Jitterer = new Random();

        private readonly DaprClient _daprClient;
        private readonly ILogger<EmailBodyIntegrationEventHandler> _logger;
        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly IEventBus _eventBus;
        private readonly IEmailSnapshotService _emailSnapshotService;
        private readonly IMapper _mapper;

        public EmailBodyIntegrationEventHandler(DaprClient daprClient, ILogger<EmailBodyIntegrationEventHandler> logger, IEventBus eventBus, IMapper mapper, IEmailSnapshotService emailSnapshotService)
        {
            _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailSnapshotService = emailSnapshotService ?? throw new ArgumentNullException(nameof(emailSnapshotService));

            _retryPolicy = Policy
                .Handle<SendMailFailedException>()
                .WaitAndRetryAsync(MaxRetryCount, attempt => GetDelayWithJitter(attempt),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        if (context.TryGetValue("event", out var eventInfoObj) && eventInfoObj is EmailBodyIntegrationEvent eventInfo)
                        {
                            _logger.LogWarning($"Retry {retryCount} encountered an error: {exception.Message}. Waiting {timeSpan} before next retry.");
                            _logger.LogInformation($"Attempt {retryCount} for event: {eventInfo}");

                            // _eventBus.PublishAsync(new SendEmailAttemptIntegrationEvent(eventInfo.EmailQueueId, retryCount));
                        }
                        else
                        {
                            _logger.LogWarning($"Retry {retryCount} encountered an error: {exception.Message}. Waiting {timeSpan} before next retry. Event info is missing.");
                        }
                    });
        }

        public async Task Handle(EmailBodyIntegrationEvent @event)
        {
            var context = new Context();
            context["event"] = @event;

            await _retryPolicy.ExecuteAsync(async (ctx) =>
            {
                try
                {
                    _logger.LogInformation("-------------------- Execute -------------------");

                    RetryCount++;

                    await _eventBus.PublishAsync(new SendEmailAttemptIntegrationEvent(@event.EmailQueueId, RetryCount));

                    await _daprClient.InvokeBindingAsync(
                        SendMailBinding,
                        CreateBindingOperation,
                        @event.EmailBody,
                        new Dictionary<string, string>
                        {
                            ["emailFrom"] = @event.EmailFrom,
                            ["emailTo"] = @event.EmailTo,
                            ["subject"] = @event.Subject
                        });

                    // Simuleer een fout om de retry te triggeren
                    // throw new SendMailFailedException("Simulated failure");

                    EmailSnapshot emailSnapshot = _mapper.Map<EmailSnapshot>(@event);

                    emailSnapshot.SentDate = DateTime.Now;

                    await _emailSnapshotService.SaveEmailSnapshotAsync(emailSnapshot);

                    await _eventBus.PublishAsync(new EmailIsSendIntegrationEvent(@event.EmailQueueId));


                }
                catch (SendMailFailedException ex)
                {
                    if (RetryCount == (MaxRetryCount + 1))
                    {
                        _logger.LogError(ex, "Sending Email Failed.");

                        await _eventBus.PublishAsync(new AllRetriesFailedIntegrationEvent(@event.EmailQueueId, ex.Message));
                    }
                    _logger.LogError(ex, "Error occurred while sending the email message.");
                    throw; // Zorg ervoor dat de uitzondering opnieuw wordt gegooid om de retry te triggeren
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while processing the email message.");

                    await _eventBus.PublishAsync(new AllRetriesFailedIntegrationEvent(@event.EmailQueueId, ex.Message));

                    throw new SendMailFailedException("Wrapped in SendMailFailedException" + ex);
                }
            }, context);
        }

        private static TimeSpan GetDelayWithJitter(int attempt)
        {
            // Base delay with exponential backoff
            var baseDelay = TimeSpan.FromSeconds(Math.Pow(2, attempt));
            // Jitter range is between 0 and 1000 milliseconds
            var jitter = TimeSpan.FromMilliseconds(Jitterer.Next(0, 1000));
            return baseDelay + jitter;
        }
    }
}