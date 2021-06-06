using System.Threading.Tasks;

namespace Armory.Shared.Domain.Bus.Event
{
    public interface IDomainEventSubscriber<in TDomain> : IDomainEventSubscriberBase where TDomain : DomainEvent
    {
        async Task IDomainEventSubscriberBase.On(DomainEvent @event)
        {
            if (@event is TDomain msg)
                await On(msg);
        }

        Task On(TDomain domainEvent);
    }
}
