using System.Threading;
using System.Threading.Tasks;
using Armory.Api.Controllers.ArmoryUsers.Authentication;
using Armory.Users.Application.Authenticate;
using Armory.Users.Application.GenerateJwt;
using Armory.Users.Application.Logout;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Armory.Api.Test.Controllers.ArmoryUsers.Authentication
{
    public class AuthenticationControllerTest : ApiTest
    {
        private AuthenticationController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new AuthenticationController(Mediator.Object);
        }

        private void ShouldHaveAuthenticate()
        {
            Mediator.Verify(x => x.Send(It.IsAny<AuthenticateCommand>(), CancellationToken.None),
                Times.AtLeastOnce());
        }

        [Test, Order(1)]
        public async Task Authenticate_With_Valid_Username_And_Password()
        {
            Mediator.Setup(x => x.Send(It.IsAny<GenerateJwtQuery>(), CancellationToken.None))
                .ReturnsAsync("auth_token");

            var result = await _controller.Authenticate(new AuthenticationRequest
            {
                UsernameOrEmail = "admin",
                Password = "admin",
                IsPersistent = true
            });

            ShouldHaveAuthenticate();

            Assert.IsNotNull(result.Result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<string>(okResult.Value);

            Assert.AreEqual("auth_token", okResult.Value as string);
        }

        [Test, Order(2)]
        public async Task Authenticate_With_Valid_Username_And_Invalid_Password()
        {
            Mediator.Setup(x => x.Send(It.IsAny<AuthenticateCommand>(), CancellationToken.None))
                .Throws<ArmoryUserNotAuthenticate>();

            var result = await _controller.Authenticate(new AuthenticationRequest
            {
                UsernameOrEmail = "admin",
                Password = "wrong",
                IsPersistent = true
            });

            ShouldHaveAuthenticate();
            Assert.IsNotNull(result.Result);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }

        [Test, Order(3)]
        public async Task Authenticate_With_Invalid_Username()
        {
            Mediator.Setup(x => x.Send(It.IsAny<AuthenticateCommand>(), CancellationToken.None))
                .Throws<ArmoryUserNotFound>();

            var result = await _controller.Authenticate(new AuthenticationRequest
            {
                UsernameOrEmail = "none",
                Password = "wrong",
                IsPersistent = true
            });

            ShouldHaveAuthenticate();
            Assert.IsNotNull(result.Result);
            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
        }


        private void ShouldHaveLogout()
        {
            Mediator.Verify(x => x.Send(It.IsAny<LogoutCommand>(), CancellationToken.None),
                Times.AtLeastOnce());
        }

        [Test, Order(4)]
        public async Task Logout()
        {
            var result = await _controller.Logout();

            ShouldHaveLogout();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}
