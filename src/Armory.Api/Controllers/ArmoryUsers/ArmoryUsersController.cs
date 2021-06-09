using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.ArmoryUsers.Requests;
using Armory.Shared.Domain;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Users.Application.ChangePassword;
using Armory.Users.Application.ConfirmEmail;
using Armory.Users.Application.Create;
using Armory.Users.Application.GeneratePasswordResetToken;
using Armory.Users.Application.ResetPassword;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Armory.Api.Controllers.ArmoryUsers
{
    [ApiController]
    [Authorize]
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

        private IActionResult IdentityErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] CreateArmoryUserRequest request)
        {
            try
            {
                await _commandBus.Dispatch(new CreateArmoryUserCommand(request.UserName, request.Email, request.Phone,
                    request.Password));
            }
            catch (ArmoryUserNotCreated e)
            {
                return IdentityErrors(e.Errors);
            }

            return Ok();
        }

        private IActionResult ArmoryUserNotFound(string usernameOrEmail)
        {
            ModelState.AddModelError("UserNotFound",
                $"El usuario identificado con '{usernameOrEmail}' no se encuentra registrado.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("[action]/{userNameOrEmail}")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgottenPassword(string userNameOrEmail)
        {
            var response = await _queryBus.Ask<PasswordResetTokenResponse>(
                new GeneratePasswordResetTokenQuery(userNameOrEmail));
            return response.TokenGenerated
                ? Ok(Utils.StringToBase64(response.Token))
                : ArmoryUserNotFound(userNameOrEmail);
        }

        [HttpPost("[action]/{usernameOrEmail}")]
        [AllowAnonymous]
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
                return ArmoryUserNotFound(usernameOrEmail);
            }
            catch (PasswordNotReset e)
            {
                return IdentityErrors(e.Errors);
            }

            return Ok();
        }

        [HttpPut("[action]/{usernameOrEmail}")]
        public async Task<IActionResult> ChangePassword(string usernameOrEmail,
            [FromBody] ChangePasswordRequest request)
        {
            try
            {
                await _commandBus.Dispatch(new ChangePasswordCommand(usernameOrEmail, request.OldPassword,
                    request.NewPassword));
            }
            catch (ArmoryUserNotFound)
            {
                return ArmoryUserNotFound(usernameOrEmail);
            }
            catch (PasswordNotChange e)
            {
                return IdentityErrors(e.Errors);
            }

            return Ok();
        }

        [HttpPost("[action]/{usernameOrEmail}")]
        public async Task<IActionResult> ConfirmEmail(string usernameOrEmail, [FromQuery] string token)
        {
            try
            {
                await _commandBus.Dispatch(new ConfirmEmailCommand(usernameOrEmail, token));
            }
            catch (ArmoryUserNotFound)
            {
                return ArmoryUserNotFound(usernameOrEmail);
            }
            catch (EmailNotConfirmed e)
            {
                return IdentityErrors(e.Errors);
            }

            return Ok();
        }
    }
}
