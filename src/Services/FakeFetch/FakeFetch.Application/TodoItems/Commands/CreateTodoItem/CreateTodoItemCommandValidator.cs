namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.FakeFetchItems.Commands.CreateFakeFetchItem;

public class CreateFakeFetchItemCommandValidator : AbstractValidator<CreateFakeFetchItemCommand>
{
    public CreateFakeFetchItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
