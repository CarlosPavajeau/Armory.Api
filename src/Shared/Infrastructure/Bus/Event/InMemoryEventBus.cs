using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Armory.Shared.Infrastructure.Bus.Event
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public InMemoryEventBus(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Publish(List<DomainEvent> events)
        {
            foreach (var @event in events)
            {
                _logger.LogInformation("Publish domain event {EventName}, {@EventInfo}", @event.EventName(), @event);
                await _mediator.Publish(@event);
            }
        }
    }
}
