using System.Threading.Tasks;
using Armory.Users.Application.Create;
using Armory.Users.Domain;
using Armory.Users.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace Armory.Users.Test.Application.Create
{
    [TestFixture]
    public class CreateCourseCommandHandlerTest : UsersModuleUnitTestCase
    {
        private readonly CreateArmoryUserCommandHandler _handler;
        private readonly SpanishIdentityErrorDescriber _spanishIdentityErrorDescriber = new();


        public CreateCourseCommandHandlerTest()
        {
            _handler = new CreateArmoryUserCommandHandler(new ArmoryUserCreator(ArmoryUserRepository.Object));

            ArmoryUserRepository.Setup(x => x.Save(It.IsAny<ArmoryUser>(), "1"))
                .ReturnsAsync(IdentityResult.Failed(_spanishIdentityErrorDescriber.PasswordTooShort(1)));
        }

        [Test]
        public void Create_A_Valid_Armory_User()
        {
            var command = new CreateArmoryUserCommand("admin", "admin@gmail.com", "3163100226", "Manolos");
            _handler.Handle(command);

            ShouldHaveSave();
        }

        [Test]
        public async Task Create_A_Invalid_Armory_User()
        {
            var command = new CreateArmoryUserCommand("admin", "admin@gmail.com", "3163100226", "1");
            try
            {
                await _handler.Handle(command);
                Assert.Fail();
            }
            catch (ArmoryUserNotCreated)
            {
                ShouldHaveSave();
                Assert.Pass();
            }
        }
    }
}
