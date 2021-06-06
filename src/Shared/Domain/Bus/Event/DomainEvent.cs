namespace Armory.Shared.Domain.Bus.Event
{
    public abstract class DomainEvent
    {
        public string AggregateId { get; set; }
        public string EventId { get; set; }
        public string OccurredOn { get; set; }

        protected DomainEvent(string aggregateId, string eventId, string occurredOn)
        {
            AggregateId = aggregateId;
            EventId = eventId;
            OccurredOn = occurredOn;
        }

        protected DomainEvent()
        {
        }

        public abstract string EventName();
    }
}
