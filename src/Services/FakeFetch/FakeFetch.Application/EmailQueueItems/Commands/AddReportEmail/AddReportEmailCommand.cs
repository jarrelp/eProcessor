using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;

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

        await _context.EmailQueueItems.AddAsync(new EmailQueueItem("REPORT", "en-US", "aangepast@email.adr", 14451, "Report Email for aangepast@email.adr", "Random Message", reportData), cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
