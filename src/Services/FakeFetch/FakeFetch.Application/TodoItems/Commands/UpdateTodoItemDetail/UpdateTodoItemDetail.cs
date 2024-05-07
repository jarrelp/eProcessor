using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Enums;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Commands.UpdateFakeFetchItemDetail;

public record UpdateFakeFetchItemDetailCommand : IRequest
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}

public class UpdateFakeFetchItemDetailCommandHandler : IRequestHandler<UpdateFakeFetchItemDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateFakeFetchItemDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateFakeFetchItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.FakeFetchItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.ListId = request.ListId;
        entity.Priority = request.Priority;
        entity.Note = request.Note;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
