using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Users.Application.Authenticate;
using Armory.Users.Application.GenerateJwt;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Armory.Api.Controllers.ArmoryUsers.Authentication
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public AuthenticationController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Authenticate([FromBody] AuthenticationRequest request)
        {
            try
            {
                await _commandBus.Dispatch(new AuthenticateCommand(request.UsernameOrEmail, request.Password,
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

            var token = await _queryBus.Ask<string>(new GenerateJwtQuery(request.UsernameOrEmail));
            return Ok(token);
        }
    }
}
