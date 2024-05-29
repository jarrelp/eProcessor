using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Domain.Entities.EmailTemplates;

namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Commands.AddLoginEmail;

public record AddLoginEmailCommand() : IRequest;


public class AddLoginEmailCommandHandler : IRequestHandler<AddLoginEmailCommand>
{
    private readonly IApplicationDbContext _context;

    public AddLoginEmailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(AddLoginEmailCommand request, CancellationToken cancellationToken)
    {
        Login loginData = new("John Doe", "Production", "192.168.23.45", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"));

        await _context.EmailQueueItems.AddAsync(new EmailQueueItem("LOGIN", "en-US", "aangepast@email.adr", 14451, "Login Email for aangepast@email.adr", "Random Message", loginData), cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
