using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Shared.Test.Infrastructure;
using Moq;

namespace Armory.Api.Test
{
    public class ApiTest : UnitTestCase
    {
        protected readonly Mock<ICommandBus> CommandBus;
        protected readonly Mock<IQueryBus> QueryBus;

        public ApiTest()
        {
            CommandBus = new Mock<ICommandBus>();
            QueryBus = new Mock<IQueryBus>();
        }
    }
}
