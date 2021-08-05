using Armory.Shared.Domain.Bus.Command.Generic;
using MediatR;

namespace Armory.Shared.Domain.Bus.Command
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : Command<TResponse>
    {
    }
}
