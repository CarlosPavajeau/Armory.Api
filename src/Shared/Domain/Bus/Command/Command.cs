using MediatR;

namespace Armory.Shared.Domain.Bus.Command
{
    public abstract class Command : IRequest
    {
    }

    public abstract class Command<TResponse> : IRequest<TResponse>
    {
    }
}
