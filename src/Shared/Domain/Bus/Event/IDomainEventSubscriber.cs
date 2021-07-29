using MediatR;

namespace Armory.Shared.Domain.Bus.Event
{
    public interface IDomainEventSubscriber<in TDomain> : INotificationHandler<TDomain> where TDomain : DomainEvent
    {
    }
}
