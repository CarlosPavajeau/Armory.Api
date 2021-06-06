using System.Threading.Tasks;

namespace Armory.Shared.Domain.Bus.Event
{
    public interface IDomainEventSubscriberBase
    {
        Task On(DomainEvent @event);
    }
}
