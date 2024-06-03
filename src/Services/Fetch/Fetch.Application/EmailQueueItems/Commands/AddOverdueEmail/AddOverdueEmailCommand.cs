// using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Commands.AddOverdueEmail;

// public record AddOverdueEmailCommand() : IRequest;


// public class AddOverdueEmailCommandHandler : IRequestHandler<AddOverdueEmailCommand>
// {
//     private readonly IApplicationDbContext _context;

//     public AddOverdueEmailCommandHandler(IApplicationDbContext context)
//     {
//         _context = context;
//     }

//     public async Task Handle(AddOverdueEmailCommand request, CancellationToken cancellationToken)
//     {
//         Overdue overdueData = new("John Doe", "john.doe@example.com", "PROD1", "Product X", "ORDER1", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));

//         await _context.EmailQueueItems.AddAsync(new EmailQueueItem("OVERDUE", "en-US", "dizzel@dizzel.dizz", 14451, "Login Email for dizzel@dizzel.dizz", "Random Message", overdueData), cancellationToken);

//         await _context.SaveChangesAsync(cancellationToken);
//     }
// }
