// using Ardalis.GuardClauses;
// using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Events;
// using Microsoft.Extensions.Logging;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EventHandling;

// public class SendEmailAttemptIntegrationEventHandler : IIntegrationEventHandler<SendEmailAttemptIntegrationEvent>
// {
//   private readonly ILogger<SendEmailAttemptIntegrationEventHandler> _logger;
//   private readonly IApplicationDbContext _context;

//   public SendEmailAttemptIntegrationEventHandler(ILogger<SendEmailAttemptIntegrationEventHandler> logger, IApplicationDbContext context)
//   {
//     _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//     _context = context ?? throw new ArgumentNullException(nameof(context));
//   }

//   public async Task Handle(SendEmailAttemptIntegrationEvent @event, CancellationToken cancellationToken)
//   {
//     var emailQueueItem = await _context.EmailQueueItems.FirstOrDefaultAsync(x => x.EmailQueueId == @event.EmailQueueId, cancellationToken);

//     if (emailQueueItem == null)
//     {
//       _logger.LogError($"EmailQueueItem with ID {@event.EmailQueueId} not found.");
//       throw new NotFoundException(@event.EmailQueueId.ToString(), nameof(EmailQueueItem));
//     }

//     emailQueueItem.Attempts = @event.Attempt;

//     try
//     {
//       await _context.SaveChangesAsync(cancellationToken);
//       _logger.LogInformation($"EmailQueueItem with ID {@event.EmailQueueId} attempts updated to {@event.Attempt}.");
//     }
//     catch (Exception ex)
//     {
//       _logger.LogError(ex, "Error occurred while updating EmailQueueItem.");
//       throw;
//     }
//   }
// }