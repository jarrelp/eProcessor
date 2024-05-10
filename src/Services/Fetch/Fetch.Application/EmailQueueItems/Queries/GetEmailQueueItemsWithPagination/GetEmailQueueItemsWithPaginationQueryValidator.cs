namespace Ecmanage.eProcessor.Services.Fetch.Fetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class GetEmailQueueItemsWithPaginationQueryValidator : AbstractValidator<GetEmailQueueItemsWithPaginationQuery>
{
  public GetEmailQueueItemsWithPaginationQueryValidator()
  {
    RuleFor(x => x.PageNumber)
        .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

    RuleFor(x => x.PageSize)
        .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
  }
}
