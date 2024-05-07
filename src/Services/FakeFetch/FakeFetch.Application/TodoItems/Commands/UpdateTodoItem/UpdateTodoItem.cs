using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Commands.UpdateFakeFetchItem;

public record UpdateFakeFetchItemCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}

public class UpdateFakeFetchItemCommandHandler : IRequestHandler<UpdateFakeFetchItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateFakeFetchItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateFakeFetchItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.FakeFetchItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;
        entity.Done = request.Done;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
