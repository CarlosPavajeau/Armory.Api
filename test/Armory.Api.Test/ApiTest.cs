using Armory.Shared.Test.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Armory.Api.Test
{
    public class ApiTest : UnitTestCase
    {
        protected readonly Mock<IMediator> Mediator;
        protected ServiceProvider Provider { get; private set; }

        public ApiTest()
        {
            Mediator = new Mock<IMediator>();

            Init();
        }

        private void Init()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddAutoMapper(typeof(Startup));

            Provider = services.BuildServiceProvider();
        }
    }
}
