using MediatR;

namespace Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.CQRS;
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}
