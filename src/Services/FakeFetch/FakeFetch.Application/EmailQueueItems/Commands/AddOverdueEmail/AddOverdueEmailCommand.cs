using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddOverdueEmail;

public record AddOverdueEmailCommand() : IRequest;


public class AddOverdueEmailCommandHandler : IRequestHandler<AddOverdueEmailCommand>
{
    private readonly IApplicationDbContext _context;

    public AddOverdueEmailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(AddOverdueEmailCommand request, CancellationToken cancellationToken)
    {
        Overdue overdueData = new("John Doe", "john.doe@example.com", "PROD1", "Product X", "ORDER1", DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));

        _context.EmailQueueItems.Add(new EmailQueueItem("OVERDUE", "en-US", "dizzel@dizzel.dizz", 14451, "Login Email for dizzel@dizzel.dizz", "Random Message", overdueData));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
