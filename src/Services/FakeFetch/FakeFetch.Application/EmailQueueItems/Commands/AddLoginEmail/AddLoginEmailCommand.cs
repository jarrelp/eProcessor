using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities.EmailTemplates;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Commands.AddLoginEmail;

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

        _context.EmailQueueItems.Add(new EmailQueueItem("LOGIN", "en-US", "aangepast@email.adr", 14451, "Login Email for aangepast@email.adr", "Random Message", loginData));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
