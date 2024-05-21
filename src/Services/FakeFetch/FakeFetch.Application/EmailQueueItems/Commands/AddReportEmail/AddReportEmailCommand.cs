using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddReportEmail;

public record AddReportEmailCommand() : IRequest;


public class AddReportEmailCommandHandler : IRequestHandler<AddReportEmailCommand>
{
    private readonly IApplicationDbContext _context;

    public AddReportEmailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(AddReportEmailCommand request, CancellationToken cancellationToken)
    {
        Report reportData = new("Portal X", "Monthly Sales Report", "http://example.com/reports/monthly-sales");

        _context.EmailQueueItems.Add(new EmailQueueItem("REPORT", "en-US", "aangepast@email.adr", 14451, "Report Email for aangepast@email.adr", "Random Message", reportData));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
