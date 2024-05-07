using MediatR;

namespace Ecmanage.eProcessor.BuildingBlocks.BuildingBlocks.Application.CQRS;

public interface ICommand : ICommand<Unit>
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
