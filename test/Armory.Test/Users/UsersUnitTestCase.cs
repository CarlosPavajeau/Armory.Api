using Armory.Shared.Test.Infrastructure;
using Armory.Users.Domain;
using Moq;

namespace Armory.Test.Users
{
    public class UsersUnitTestCase : UnitTestCase
    {
        protected readonly Mock<IArmoryUsersRepository> Repository;

        protected UsersUnitTestCase()
        {
            Repository = new Mock<IArmoryUsersRepository>();
        }
    }
}
