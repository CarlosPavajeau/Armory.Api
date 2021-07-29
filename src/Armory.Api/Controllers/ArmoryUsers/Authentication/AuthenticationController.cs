using System.Threading.Tasks;
using Armory.Users.Application.Authenticate;
using Armory.Users.Application.GenerateJwt;
using Armory.Users.Application.Logout;
using Armory.Users.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Armory.Api.Controllers.ArmoryUsers.Authentication
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Authenticate([FromBody] AuthenticationRequest request)
        {
            try
            {
                await _mediator.Send(new AuthenticateCommand(request.UsernameOrEmail, request.Password,
                    request.IsPersistent));
            }
            catch (ArmoryUserNotAuthenticate)
            {
                ModelState.AddModelError("IncorrectPassword", "Contraseña de acceso incorrecta.");
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (ArmoryUserNotFound)
            {
                ModelState.AddModelError("UserNotFound",
                    $"El usuario identificado con '{request.UsernameOrEmail}' no se encuentra registrado.");
                return NotFound(new ValidationProblemDetails(ModelState));
            }

            var token = await _mediator.Send(new GenerateJwtQuery(request.UsernameOrEmail));
            return Ok(token);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Logout()
        {
            await _mediator.Send(new LogoutCommand());
            return Ok();
        }
    }
}
