using System.Collections.Generic;
using Armory.Shared.Domain.Bus.Event;
using Moq;

namespace Armory.Shared.Test.Infrastructure
{
    public class UnitTestCase
    {
        protected readonly Mock<IEventBus> EventBus;

        public UnitTestCase()
        {
            EventBus = new Mock<IEventBus>();
        }

        public void ShouldHavePublished(List<DomainEvent> domainEvents)
        {
            EventBus.Verify(x => x.Publish(domainEvents), Times.AtLeastOnce());
        }

        public void ShouldHavePublished(DomainEvent domainEvent)
        {
            ShouldHavePublished(new List<DomainEvent> {domainEvent});
        }
    }
}
