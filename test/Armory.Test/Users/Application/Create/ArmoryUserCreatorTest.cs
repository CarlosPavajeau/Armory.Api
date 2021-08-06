using System;
using System.Linq;
using System.Threading.Tasks;
using Armory.Users.Application.AddToRole;
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
            _creator = new ArmoryUserCreator(Repository.Object, new RoleAggregator(Repository.Object));
            _describer = new SpanishIdentityErrorDescriber();

            SetUpRepository();
        }

        private void SetUpRepository()
        {
            Repository.Setup(x => x.Save(It.IsAny<ArmoryUser>(), It.IsAny<string>()))
                .ReturnsAsync((ArmoryUser user, string _) => string.IsNullOrEmpty(user.UserName)
                    ? IdentityResult.Failed(_describer.InvalidUserName(user.UserName))
                    : IdentityResult.Success);

            Repository.Setup(x => x.AddToRole(It.IsAny<ArmoryUser>(), It.IsAny<string>()))
                .ReturnsAsync((ArmoryUser _, string roleName) =>
                {
                    if (string.IsNullOrEmpty(roleName)) throw new InvalidOperationException();

                    return roleName == "nadmin"
                        ? IdentityResult.Failed(_describer.InvalidRoleName(roleName))
                        : IdentityResult.Success;
                });
        }

        private void ShouldHaveSave()
        {
            Repository.Verify(x => x.Save(It.IsAny<ArmoryUser>(), It.IsAny<string>()), Times.AtLeastOnce());
        }

        [Test]
        [Order(1)]
        public async Task Create_A_Valid_ArmoryUser()
        {
            var user = await _creator.Create("admin", "admin@admin.com", "3000000000", "admin", "admin");

            ShouldHaveSave();
            Assert.IsNotNull(user);
        }

        [Test]
        [Order(2)]
        public async Task Create_An_Invalid_ArmoryUser()
        {
            try
            {
                _ = await _creator.Create("", "admin@admin.com", "3000000000", "admin", "admin");

                Assert.Fail();
            }
            catch (ArmoryUserNotCreated)
            {
                ShouldHaveSave();
                Assert.Pass();
            }
        }

        [Test]
        [Order(3)]
        public async Task Create_A_Valid_ArmoryUser_With_Invalid_RoleName()
        {
            try
            {
                _ = await _creator.Create("admin", "admin@admin.com", "3000000000", "admin", "nadmin");

                Assert.Fail();
            }
            catch (ArmoryUserNotCreated e)
            {
                ShouldHaveSave();

                Assert.IsNotNull(e.Errors);
                Assert.AreEqual(1, e.Errors.Count());
                Assert.AreEqual("InvalidRoleName", e.Errors.ElementAt(0).Code);
                Assert.Pass();
            }
        }

        [Test]
        [Order(4)]
        public async Task Create_A_Valid_ArmoryUser_With_Non_Existing_RoleName()
        {
            try
            {
                _ = await _creator.Create("admin", "admin@admin.com", "3000000000", "admin", "");

                Assert.Fail();
            }
            catch (ArmoryUserNotCreated e)
            {
                ShouldHaveSave();

                Assert.IsNotNull(e.Errors);
                Assert.AreEqual(1, e.Errors.Count());
                Assert.AreEqual("RoleDoesNotExists", e.Errors.ElementAt(0).Code);
                Assert.Pass();
            }
        }
    }
}
