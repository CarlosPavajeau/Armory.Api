using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Shared.Infrastructure.Bus.Command
{
    public class InMemoryCommandBus : ICommandBus
    {
        private static readonly ConcurrentDictionary<Type, IEnumerable<CommandHandlerWrapper>> CommandHandlers = new();

        private readonly IServiceProvider _provider;

        public InMemoryCommandBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task Dispatch(Domain.Bus.Command.Command command)
        {
            var wrappedHandlers = GetWrappedHandlers(command);
            if (wrappedHandlers == null)
            {
                throw new CommandNotRegisteredError(command);
            }

            foreach (var handler in wrappedHandlers)
            {
                await handler.Handle(command, _provider);
            }
        }

        private IEnumerable<CommandHandlerWrapper> GetWrappedHandlers(Domain.Bus.Command.Command command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            var wrapperType = typeof(CommandHandlerWrapper<>).MakeGenericType(command.GetType());

            var handlers =
                (IEnumerable) _provider.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType));
            Debug.Assert(handlers != null, nameof(handlers) + " != null");

            var wrappedHandlers = CommandHandlers.GetOrAdd(command.GetType(), handlers.Cast<object>()
                .Select(_ => (CommandHandlerWrapper) Activator.CreateInstance(wrapperType)));

            return wrappedHandlers;
        }
    }
}
