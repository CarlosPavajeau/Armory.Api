using System.Linq;
using System.Threading.Tasks;
using Armory.Api.Controllers.ArmoryUsers;
using Armory.Api.Controllers.ArmoryUsers.Requests;
using Armory.Shared.Domain;
using Armory.Users.Application.Create;
using Armory.Users.Application.GeneratePasswordResetToken;
using Armory.Users.Domain;
using Armory.Users.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Armory.Api.Test.Controllers.ArmoryUsers
{
    [TestFixture]
    public class ArmoryUsersControllerTest : ApiTest
    {
        private ArmoryUsersController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new ArmoryUsersController(CommandBus.Object, QueryBus.Object);
        }

        private void ShouldHaveSave()
        {
            CommandBus.Verify(x => x.Dispatch(It.IsAny<CreateArmoryUserCommand>()), Times.AtLeastOnce());
        }

        [Test, Order(1)]
        public async Task Create_A_Valid_User()
        {
            var result = await _controller.RegisterUser(
                new CreateArmoryUserRequest
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    Password = "adminpassword",
                    Phone = "3000000000"
                });

            ShouldHaveSave();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test, Order(2)]
        public async Task Create_An_Invalid_User()
        {
            var spanishIdentityErrorDescriber = new SpanishIdentityErrorDescriber();
            CommandBus.Setup(x => x.Dispatch(It.IsAny<CreateArmoryUserCommand>()))
                .Throws(new ArmoryUserNotCreated(new[] {spanishIdentityErrorDescriber.DefaultError()}));

            var result = await _controller.RegisterUser(
                new CreateArmoryUserRequest
                {
                    UserName = "fail",
                    Email = "fail",
                    Password = "fail",
                    Phone = "fail"
                });

            ShouldHaveSave();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        private void ShouldHaveForgottenPasswordQuery()
        {
            QueryBus.Verify(x => x.Ask<PasswordResetTokenResponse>(It.IsAny<GeneratePasswordResetTokenQuery>()),
                Times.AtLeastOnce());
        }

        [Test, Order(3)]
        public async Task Forgotten_Password_With_An_Existing_User()
        {
            QueryBus.Setup(x => x.Ask<PasswordResetTokenResponse>(It.IsAny<GeneratePasswordResetTokenQuery>()))
                .ReturnsAsync(new PasswordResetTokenResponse("reset_token"));

            var result = await _controller.ForgottenPassword("admin");

            ShouldHaveForgottenPasswordQuery();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<string>(okResult.Value);
            Assert.AreEqual("reset_token", Utils.Base64ToString(okResult.Value as string));
        }

        [Test, Order(4)]
        public async Task Forgotten_Password_With_A_Non_Existent_User()
        {
            QueryBus.Setup(x => x.Ask<PasswordResetTokenResponse>(It.IsAny<GeneratePasswordResetTokenQuery>()))
                .ReturnsAsync(new PasswordResetTokenResponse());

            var result = await _controller.ForgottenPassword("fail");

            ShouldHaveForgottenPasswordQuery();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundObjectResult>(result);

            var notFoundResult = result as NotFoundObjectResult;

            Assert.IsNotNull(notFoundResult);
            Assert.IsInstanceOf<ValidationProblemDetails>(notFoundResult.Value);

            var validationDetails = notFoundResult.Value as ValidationProblemDetails;

            Assert.IsNotNull(validationDetails);
            Assert.IsTrue(validationDetails.Errors.TryGetValue("UserNotFound", out var errors));
            Assert.IsTrue(errors.Any());
            Assert.AreEqual("El usuario identificado con 'fail' no se encuentra registrado.", errors[0]);
        }
    }
}
