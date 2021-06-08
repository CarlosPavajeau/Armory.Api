using System;
using System.Threading.Tasks;
using Armory.Shared.Domain;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Users.Application.Create;
using Armory.Users.Application.GeneratePasswordResetToken;
using Armory.Users.Application.ResetPassword;
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
        public async Task<IActionResult> ForgottenPassword(string userNameOrEmail)
        {
            var response = await _queryBus.Ask<PasswordResetTokenResponse>(
                new GeneratePasswordResetTokenQuery(userNameOrEmail));
            if (response.TokenGenerated)
            {
                return Ok(Utils.StringToBase64(response.Token));
            }

            ModelState.AddModelError("UserNotFound",
                $"El usuario identificado con '{userNameOrEmail}' no se encuentra registrado.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("[action]/{usernameOrEmail}")]
        public async Task<IActionResult> ResetPassword(string usernameOrEmail, [FromBody] ResetPasswordRequest request)
        {
            try
            {
                await _commandBus.Dispatch(
                    new ResetPasswordCommand(usernameOrEmail, request.Token, request.NewPassword));
            }
            catch (FormatException)
            {
                ModelState.AddModelError("InvalidToken", "El token de restablecimiento de contraseña es inválido.");
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (ArmoryUserNotFound)
            {
                ModelState.AddModelError("UserNotFound",
                    $"El usuario identificado con '{usernameOrEmail}' no se encuentra registrado.");
                return NotFound(new ValidationProblemDetails(ModelState));
            }
            catch (PasswordNotReset e)
            {
                foreach (var error in e.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }
    }
}
