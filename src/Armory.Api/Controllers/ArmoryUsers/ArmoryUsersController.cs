using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Users.Application.Create;
using Armory.Users.Application.GeneratePasswordResetToken;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Armory.Api.Controllers.ArmoryUsers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmoryUsersController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public ArmoryUsersController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] CreateArmoryUserRequest request)
        {
            try
            {
                await _commandBus.Dispatch(new CreateArmoryUserCommand(request.UserName, request.Email, request.Phone,
                    request.Password));
            }
            catch (ArmoryUserNotCreate e)
            {
                foreach (var error in e.Result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        [HttpPost("[action]/{userNameOrEmail}")]
        public async Task<IActionResult> ResetPassword(string userNameOrEmail)
        {
            var response = await _queryBus.Ask<PasswordResetTokenResponse>(
                new GeneratePasswordResetTokenQuery(userNameOrEmail));
            if (response.TokenGenerated)
            {
                return Ok();
            }

            ModelState.AddModelError("UserNotFound",
                $"El usuario identificado con '{userNameOrEmail}' no se encuentra registrado.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }
    }
}
