using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.ArmoryUsers.Requests;
using Armory.Shared.Domain;
using Armory.Users.Application;
using Armory.Users.Application.ChangePassword;
using Armory.Users.Application.ConfirmEmail;
using Armory.Users.Application.GeneratePasswordResetToken;
using Armory.Users.Application.ResetPassword;
using Armory.Users.Application.SearchAllRoles;
using Armory.Users.Domain;
using AutoMapper;
using MediatR;
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
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ArmoryUsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private IActionResult IdentityErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
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
            var response = await _mediator.Send(
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
                var command = _mapper.Map<ResetPasswordCommand>(request);
                await _mediator.Send(command);
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
                var command = _mapper.Map<ChangePasswordCommand>(request);
                await _mediator.Send(command);
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
                await _mediator.Send(new ConfirmEmailCommand(usernameOrEmail, token));
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

        [HttpGet("Roles")]
        public async Task<ActionResult<IEnumerable<ArmoryRoleResponse>>> GetRoles()
        {
            var roles = await _mediator.Send(new SearchAllRolesQuery());
            return Ok(roles);
        }
    }
}
