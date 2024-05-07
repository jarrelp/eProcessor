using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;
using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Domain.Entities;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Commands.CreateFakeFetchList;

public record CreateFakeFetchListCommand : IRequest<int>
{
    public string? Title { get; init; }
}

public class CreateFakeFetchListCommandHandler : IRequestHandler<CreateFakeFetchListCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateFakeFetchListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFakeFetchListCommand request, CancellationToken cancellationToken)
    {
        var entity = new FakeFetchList();

        entity.Title = request.Title;

        _context.FakeFetchLists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
