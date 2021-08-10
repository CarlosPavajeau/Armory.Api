using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using MediatR;

namespace Armory.Shared.Infrastructure.Bus.Event
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly IMediator _mediator;

        public InMemoryEventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish(List<DomainEvent> events)
        {
            foreach (var @event in events)
            {
                await _mediator.Publish(@event);
            }
        }
    }
}
