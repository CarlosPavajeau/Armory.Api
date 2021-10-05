using System;
using MediatR;

namespace Armory.Shared.Domain.Bus.Event
{
    public abstract class DomainEvent : INotification
    {
        protected DomainEvent(string aggregateId, string eventId, string occurredOn)
        {
            AggregateId = aggregateId;
            EventId = eventId;
            OccurredOn = occurredOn;
        }

        protected DomainEvent(string aggregateId) : this(aggregateId, Guid.NewGuid().ToString(),
            DateTime.Now.ToString("g"))
        {
        }

        protected DomainEvent() : this(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now.ToString("d"))
        {
        }

        public string AggregateId { get; }
        public string EventId { get; }
        public string OccurredOn { get; }

        public abstract string EventName();
    }
}
