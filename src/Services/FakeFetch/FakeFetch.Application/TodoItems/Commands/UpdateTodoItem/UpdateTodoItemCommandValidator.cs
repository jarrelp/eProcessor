namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Commands.UpdateFakeFetchItem;

public class UpdateFakeFetchItemCommandValidator : AbstractValidator<UpdateFakeFetchItemCommand>
{
    public UpdateFakeFetchItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
