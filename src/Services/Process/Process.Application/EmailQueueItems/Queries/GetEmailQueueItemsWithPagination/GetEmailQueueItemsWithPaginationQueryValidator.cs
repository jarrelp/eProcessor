namespace Ecmanage.eProcessor.Services.Process.Process.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public class GetEmailQueueItemsWithPaginationQueryValidator : AbstractValidator<GetEmailQueueItemsWithPaginationQuery>
{
  public GetEmailQueueItemsWithPaginationQueryValidator()
  {
    RuleFor(x => x.EmailQueueId)
        .GreaterThanOrEqualTo(1).WithMessage("EmailQueueId at least greater than or equal to 1.");
  }
}
