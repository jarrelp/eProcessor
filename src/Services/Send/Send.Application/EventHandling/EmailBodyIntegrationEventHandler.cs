using Dapr.Client;
using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.EventHandling
{
    public class EmailBodyIntegrationEventHandler : IIntegrationEventHandler<EmailBodyIntegrationEvent>
    {
        private readonly DaprClient _daprClient;
        private readonly ILogger<EmailBodyIntegrationEventHandler> _logger;
        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly IEventBus _eventBus;
        private readonly IEmailSnapshotService _emailSnapshotService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        private const string SendMailBinding = "sendmail";
        private const string CreateBindingOperation = "create";
        private int RetryCount = 0;
        private readonly int _maxRetryCount;
        private static readonly Random Jitterer = new();

        public EmailBodyIntegrationEventHandler(DaprClient daprClient, ILogger<EmailBodyIntegrationEventHandler> logger, IEventBus eventBus, IMapper mapper, IEmailSnapshotService emailSnapshotService, IConfiguration configuration)
        {
            _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailSnapshotService = emailSnapshotService ?? throw new ArgumentNullException(nameof(emailSnapshotService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _maxRetryCount = int.TryParse(_configuration["EmailSending:Retries"], out var retries) ? retries : 2;

            _retryPolicy = Policy
                .Handle<SendMailFailedException>()
                .WaitAndRetryAsync(_maxRetryCount, GetDelayWithJitter);
        }

        public async Task Handle(EmailBodyIntegrationEvent @event, CancellationToken cancellationToken)
        {
            await _retryPolicy.ExecuteAsync(async () =>
            {
                try
                {
                    RetryCount++;

                    try
                    {
                        await _eventBus.PublishAsync(new SendEmailAttemptIntegrationEvent(@event.EmailQueueId, RetryCount), cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error publishing IntegrationEvent", ex);
                    }

                    // Uncomment this to trigger the retry
                    // throw new SendMailFailedException("Simulated failure");

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

                    EmailSnapshot emailSnapshot = _mapper.Map<EmailSnapshot>(@event) ?? throw new Exception("Unsupported EmailBodyIntegrationEvent type for EmailSnapshot mapping.");

                    emailSnapshot.SentDate = DateTime.Now;
                    await _emailSnapshotService.SaveEmailSnapshotAsync(emailSnapshot);

                    try
                    {
                        await _eventBus.PublishAsync(new EmailIsSendIntegrationEvent(@event.EmailQueueId), cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error publishing IntegrationEvent", ex);
                    }
                }
                catch (SendMailFailedException ex)
                {
                    if (RetryCount == (_maxRetryCount - 1))
                    {
                        _logger.LogError(ex, "Sending Email Failed.");

                        try
                        {
                            await _eventBus.PublishAsync(new AllRetriesFailedIntegrationEvent(@event.EmailQueueId, ex.Message), cancellationToken);
                        }
                        catch (Exception exc)
                        {
                            throw new Exception("Error publishing IntegrationEvent", exc);
                        }
                    }
                    _logger.LogError(ex, "Error occurred while sending the email message.");
                    throw; // Ensure the exception is rethrown to trigger retry
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unknown error ocurred.");

                    throw new Exception("Unknown error ocurred" + (ex != null ? ex.ToString() : ""));
                }
            });
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