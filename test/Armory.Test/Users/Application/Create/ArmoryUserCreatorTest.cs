using System.Threading.Tasks;
using Armory.Users.Application.Create;
using Armory.Users.Domain;
using Armory.Users.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace Armory.Test.Users.Application.Create
{
    public class ArmoryUserCreatorTest : UsersUnitTestCase
    {
        private readonly ArmoryUserCreator _creator;
        private readonly SpanishIdentityErrorDescriber _describer;

        public ArmoryUserCreatorTest()
        {
            _creator = new ArmoryUserCreator(Repository.Object);
            _describer = new SpanishIdentityErrorDescriber();

            SetUpRepository();
        }

        private void SetUpRepository()
        {
            Repository.Setup(x => x.Save(It.IsAny<ArmoryUser>(), It.IsAny<string>()))
                .ReturnsAsync((ArmoryUser user, string _) => string.IsNullOrEmpty(user.UserName)
                    ? IdentityResult.Failed(_describer.InvalidUserName(user.UserName))
                    : IdentityResult.Success);
        }

        private void ShouldHaveSave()
        {
            Repository.Verify(x => x.Save(It.IsAny<ArmoryUser>(), It.IsAny<string>()), Times.AtLeastOnce());
        }

        [Test]
        [Order(1)]
        public async Task Create_A_Valid_ArmoryUser()
        {
            var user = await _creator.Create("admin", "admin@admin.com", "3000000000", "admin");

            ShouldHaveSave();
            Assert.IsNotNull(user);
        }

        [Test]
        [Order(2)]
        public async Task Create_An_Invalid_ArmoryUser()
        {
            try
            {
                _ = await _creator.Create("", "admin@admin.com", "3000000000", "admin");

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
