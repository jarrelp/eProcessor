using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Fetch.Fetch.Application.Common.Models;

namespace Ecmanage.eProcessor.Services.Process.Process.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

public record GetEmailQueueItemsWithPaginationQuery : IRequest<EmailBodyDto>
{
    public int EmailQueueId { get; init; } = 1;
}

public class GetEmailQueueItemsWithPaginationQueryHandler : IRequestHandler<GetEmailQueueItemsWithPaginationQuery, EmailBodyDto>
{
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public GetEmailQueueItemsWithPaginationQueryHandler(IMapper mapper, IEventBus eventBus)
    {
        _mapper = mapper;
        _eventBus = eventBus;
    }

    public async Task<EmailBodyDto> Handle(GetEmailQueueItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new EmailBodyDto();
    }
}
