namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class GetNonProcessedEmailQueueItemsItemsWithPaginationQueryValidator : AbstractValidator<GetEmailQueueItemsWithPaginationQuery>
{
  public GetNonProcessedEmailQueueItemsItemsWithPaginationQueryValidator()
  {
    RuleFor(x => x.PageNumber)
        .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

    RuleFor(x => x.PageSize)
        .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
  }
}
