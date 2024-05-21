using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddUserEmail;

public record AddUserEmailCommand() : IRequest;


public class AddUserEmailCommandHandler : IRequestHandler<AddUserEmailCommand>
{
    private readonly IApplicationDbContext _context;

    public AddUserEmailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(AddUserEmailCommand request, CancellationToken cancellationToken)
    {
        User userData = new("header.jpg", "gerrit.janssen@example.com", "Gerrit Janssen", "gerritjanssen", "password123", "Example Company", "http://example.com");

        _context.EmailQueueItems.Add(new EmailQueueItem("USER", "en-US", "dizzel@dizzel.dizz", 14451, "User Email for dizzel@dizzel.dizz", "Random Message", userData));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
