using Armory.Shared.Test.Infrastructure;
using Armory.Users.Domain;
using Moq;

namespace Armory.Users.Test
{
    public class UsersModuleUnitTestCase : UnitTestCase
    {
        protected readonly Mock<IArmoryUserRepository> ArmoryUserRepository;

        protected UsersModuleUnitTestCase()
        {
            ArmoryUserRepository = new Mock<IArmoryUserRepository>();
        }

        protected void ShouldHaveSave()
        {
            ArmoryUserRepository.Verify(x =>
                x.Save(It.IsAny<ArmoryUser>(), It.IsAny<string>()), Times.AtLeastOnce());
        }
    }
}
