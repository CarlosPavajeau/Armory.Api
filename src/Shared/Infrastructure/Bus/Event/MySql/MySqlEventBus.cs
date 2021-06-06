using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using Microsoft.EntityFrameworkCore;

namespace Armory.Shared.Infrastructure.Bus.Event.MySql
{
    public class MySqlEventBus : IEventBus
    {
        private readonly DbContext _context;

        public MySqlEventBus(DbContext eventContext)
        {
            _context = eventContext;
        }

        public async Task Publish(List<DomainEvent> events)
        {
            foreach (var domainEvent in events)
            {
                await Publish(domainEvent);
            }
        }

        private async Task Publish(DomainEvent domainEvent)
        {
            var value = new DomainEventPrimitive
            {
                Id = domainEvent.EventId,
                AggregateId = domainEvent.AggregateId,
                Name = domainEvent.EventName(),
                OccurredOn = domainEvent.OccurredOn
            };

            await _context.Set<DomainEventPrimitive>().AddAsync(value);
            await _context.SaveChangesAsync();
        }
    }
}
