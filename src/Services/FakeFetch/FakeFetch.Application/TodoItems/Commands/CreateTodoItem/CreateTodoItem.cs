using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Events;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Commands.CreateFakeFetchItem;

public record CreateFakeFetchItemCommand : IRequest<int>
{
    public int ListId { get; init; }

    public string? Title { get; init; }
}

public class CreateFakeFetchItemCommandHandler : IRequestHandler<CreateFakeFetchItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateFakeFetchItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFakeFetchItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new FakeFetchItem
        {
            ListId = request.ListId,
            Title = request.Title,
            Done = false
        };

        entity.AddDomainEvent(new FakeFetchItemCreatedEvent(entity));

        _context.FakeFetchItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
