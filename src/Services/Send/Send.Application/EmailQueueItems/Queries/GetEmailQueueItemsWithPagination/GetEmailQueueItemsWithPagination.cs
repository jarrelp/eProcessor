using Ecmanage.eProcessor.BuildingBlocks.EventBus.Abstractions;
using Ecmanage.eProcessor.Services.Send.Send.Application.Common.Models;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Entities.EmailTemplates;
using Ecmanage.eProcessor.Services.Send.Send.Domain.Events;

namespace Ecmanage.eProcessor.Services.Send.Send.Application.EmailQueueItems.Queries.GetEmailQueueItemsWithPagination;

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
