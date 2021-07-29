using System.Collections.Generic;
using System.Threading;
using Armory.Shared.Domain.Bus.Event;
using MediatR;
using Moq;

namespace Armory.Shared.Test.Infrastructure
{
    public class UnitTestCase
    {
        protected readonly Mock<IMediator> EventBus;

        public UnitTestCase()
        {
            EventBus = new Mock<IMediator>();
        }

        public void ShouldHavePublished(List<DomainEvent> domainEvents)
        {
            EventBus.Verify(x => x.Publish(domainEvents, CancellationToken.None), Times.AtLeastOnce());
        }

        public void ShouldHavePublished(DomainEvent domainEvent)
        {
            ShouldHavePublished(new List<DomainEvent> {domainEvent});
        }
    }
}
