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

        protected DomainEvent()
        {
        }

        public string AggregateId { get; set; }
        public string EventId { get; set; }
        public string OccurredOn { get; set; }

        public abstract string EventName();
    }
}
