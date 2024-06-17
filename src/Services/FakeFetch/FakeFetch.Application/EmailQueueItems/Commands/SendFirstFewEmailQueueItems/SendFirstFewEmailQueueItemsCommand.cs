using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Helpers;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Services;
using Microsoft.Extensions.Logging;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.SendFirstFewEmailQueueItems;

public record SendFirstFewEmailQueueItemsCommand() : IRequest;

public class SendFirstFewEmailQueueItemsCommandHandler : IRequestHandler<SendFirstFewEmailQueueItemsCommand>
{
    private readonly IEmailProcessingService _emailProcessingService;
    private readonly IEmailQueueManager _emailQueueManager;
    private readonly ILogger<SendFirstFewEmailQueueItemsCommandHandler> _logger;

    public SendFirstFewEmailQueueItemsCommandHandler(
        IEmailProcessingService emailProcessingService,
        IEmailQueueManager emailQueueManager,
        ILogger<SendFirstFewEmailQueueItemsCommandHandler> logger)
    {
        _emailProcessingService = emailProcessingService;
        _emailQueueManager = emailQueueManager;
        _logger = logger;
    }

    public async Task Handle(SendFirstFewEmailQueueItemsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (_emailQueueManager.GetIsBusy())
            {
                _logger.LogInformation("Email Processor System is busy!");
                return;
            }
            await _emailProcessingService.FetchAndPublishEmailsAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while processing email queue items.");
            throw;
        }

        return;
    }
}