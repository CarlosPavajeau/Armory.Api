using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using Microsoft.Extensions.DependencyInjection;

namespace Armory.Shared.Infrastructure.Bus.Event
{
    public class InMemoryApplicationEventBus : IEventBus
    {
        private readonly IServiceProvider _provider;

        public InMemoryApplicationEventBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task Publish(List<DomainEvent> events)
        {
            if (events == null)
            {
                return;
            }

            using var scope = _provider.CreateScope();
            foreach (var @event in events)
            {
                var subscribers = GetSubscribers(@event, scope);

                foreach (var subscriber in subscribers)
                {
                    await ((IDomainEventSubscriberBase) subscriber).On(@event);
                }
            }
        }

        private static IEnumerable<object> GetSubscribers(DomainEvent @event, IServiceScope scope)
        {
            var eventType = @event.GetType();
            var subscriberType = typeof(IDomainEventSubscriber<>).MakeGenericType(eventType);
            return scope.ServiceProvider.GetServices(subscriberType);
        }
    }
}
