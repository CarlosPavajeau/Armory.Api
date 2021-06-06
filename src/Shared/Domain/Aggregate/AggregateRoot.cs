using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Event;

namespace Armory.Shared.Domain.Aggregate
{
    public abstract class AggregateRoot
    {
        private List<DomainEvent> _domainEvents = new();

        public List<DomainEvent> PullDomainEvents()
        {
            var events = _domainEvents;
            _domainEvents = new List<DomainEvent>();

            return events;
        }

        protected void Record(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
