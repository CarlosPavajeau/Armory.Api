using System.Threading.Tasks;

namespace Armory.Shared.Domain.Bus.Event
{
    public interface IDomainEventsConsumer
    {
        Task Consume();
    }
}
