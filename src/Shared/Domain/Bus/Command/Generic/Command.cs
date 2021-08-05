using MediatR;

namespace Armory.Shared.Domain.Bus.Command.Generic
{
    public abstract class Command<TResponse> : IRequest<TResponse>
    {
    }
}
