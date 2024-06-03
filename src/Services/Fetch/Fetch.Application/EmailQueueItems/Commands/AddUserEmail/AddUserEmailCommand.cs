// using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
// using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

// namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Commands.AddUserEmail;

// public record AddUserEmailCommand() : IRequest;


// public class AddUserEmailCommandHandler : IRequestHandler<AddUserEmailCommand>
// {
//     private readonly IApplicationDbContext _context;

//     public AddUserEmailCommandHandler(IApplicationDbContext context)
//     {
//         _context = context;
//     }

//     public async Task Handle(AddUserEmailCommand request, CancellationToken cancellationToken)
//     {
//         User userData = new("header.jpg", "gerrit.janssen@example.com", "Gerrit Janssen", "gerritjanssen", "password123", "Example Company", "http://example.com");

//         await _context.EmailQueueItems.AddAsync(new EmailQueueItem("USER", "en-US", "dizzel@dizzel.dizz", 14451, "User Email for dizzel@dizzel.dizz", "Random Message", userData), cancellationToken);

//         await _context.SaveChangesAsync(cancellationToken);
//     }
// }
