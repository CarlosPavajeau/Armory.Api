namespace Armory.Shared.Domain.Bus.Event
{
    public class DomainEventPrimitive
    {
        public string Id { get; set; }
        public string AggregateId { get; set; }
        public string Name { get; set; }
        public string OccurredOn { get; set; }
    }
}
