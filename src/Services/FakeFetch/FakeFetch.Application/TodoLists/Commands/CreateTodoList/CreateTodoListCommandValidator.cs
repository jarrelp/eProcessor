using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Commands.CreateFakeFetchList;

public class CreateFakeFetchListCommandValidator : AbstractValidator<CreateFakeFetchListCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateFakeFetchListCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(BeUniqueTitle)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.FakeFetchLists
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
