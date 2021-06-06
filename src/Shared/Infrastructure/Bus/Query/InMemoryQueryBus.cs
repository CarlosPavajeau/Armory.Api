using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Shared.Infrastructure.Bus.Query
{
    public class InMemoryQueryBus : IQueryBus
    {
        private static readonly ConcurrentDictionary<Type, object> QueryHandlers = new();

        private readonly IServiceProvider _provider;

        public InMemoryQueryBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResponse> Ask<TResponse>(Domain.Bus.Query.Query request)
        {
            var handler = GetWrappedHandlers<TResponse>(request);
            if (handler == null)
            {
                throw new QueryNotRegisteredError(request);
            }

            return await handler.Handle(request, _provider);
        }

        private QueryHandlerWrapper<TResponse> GetWrappedHandlers<TResponse>(Domain.Bus.Query.Query query)
        {
            Type[] typeArgs = {query.GetType(), typeof(TResponse)};

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(typeArgs);
            var wrapperType = typeof(QueryHandlerWrapper<,>).MakeGenericType(typeArgs);

            var handlers =
                (IEnumerable) _provider.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType));
            Debug.Assert(handlers != null, nameof(handlers) + " != null");

            var wrappedHandlers = (QueryHandlerWrapper<TResponse>) QueryHandlers.GetOrAdd(query.GetType(),
                handlers.Cast<object>()
                    .Select(_ => (QueryHandlerWrapper<TResponse>) Activator.CreateInstance(wrapperType))
                    .FirstOrDefault());

            return wrappedHandlers;
        }
    }
}
