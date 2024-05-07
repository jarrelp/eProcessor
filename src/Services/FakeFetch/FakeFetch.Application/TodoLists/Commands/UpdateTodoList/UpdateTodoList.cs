using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Commands.UpdateFakeFetchList;

public record UpdateFakeFetchListCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateFakeFetchListCommandHandler : IRequestHandler<UpdateFakeFetchListCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateFakeFetchListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateFakeFetchListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.FakeFetchLists
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);

    }
}
