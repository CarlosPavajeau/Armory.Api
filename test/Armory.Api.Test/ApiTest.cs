using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Shared.Test.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Armory.Api.Test
{
    public class ApiTest : UnitTestCase
    {
        protected readonly Mock<ICommandBus> CommandBus;
        protected readonly Mock<IQueryBus> QueryBus;
        protected ServiceProvider Provider { get; private set; }

        public ApiTest()
        {
            CommandBus = new Mock<ICommandBus>();
            QueryBus = new Mock<IQueryBus>();

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
