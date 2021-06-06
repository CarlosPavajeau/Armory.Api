using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Armory.Shared.Domain.Bus.Command
{
    internal abstract class CommandHandlerWrapper
    {
        public abstract Task Handle(Command command, IServiceProvider provider);
    }

    internal class CommandHandlerWrapper<TCommand> : CommandHandlerWrapper where TCommand : Command
    {
        public override async Task Handle(Command command, IServiceProvider provider)
        {
            var handler = (ICommandHandler<TCommand>) provider.GetService(typeof(ICommandHandler<TCommand>));
            Debug.Assert(handler != null, nameof(handler) + " != null");

            await handler.Handle((TCommand) command);
        }
    }
}
