using Armory.Shared.Test.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Armory.Api.Test
{
    public class ApiTest : UnitTestCase
    {
        protected readonly Mock<IMediator> Mediator;

        public ApiTest()
        {
            Mediator = new Mock<IMediator>();

            Init();
        }

        protected ServiceProvider Provider { get; private set; }

        private void Init()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(Startup));

            Provider = services.BuildServiceProvider();
        }
    }
}
