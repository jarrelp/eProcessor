using Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.Common.Interfaces;

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchLists.Commands.UpdateFakeFetchList;

public class UpdateFakeFetchListCommandValidator : AbstractValidator<UpdateFakeFetchListCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateFakeFetchListCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(200)
            .MustAsync(BeUniqueTitle)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniqueTitle(UpdateFakeFetchListCommand model, string title, CancellationToken cancellationToken)
    {
        return await _context.FakeFetchLists
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
