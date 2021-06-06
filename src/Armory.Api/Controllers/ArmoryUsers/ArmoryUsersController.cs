using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using Armory.Users.Application.Create;
using Armory.Users.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Armory.Api.Controllers.ArmoryUsers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmoryUsersController : ControllerBase
    {
        private readonly ICommandBus _bus;

        public ArmoryUsersController(ICommandBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] CreateArmoryUserRequest request)
        {
            try
            {
                await _bus.Dispatch(new CreateArmoryUserCommand(request.UserName, request.Email, request.Phone,
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
    }
}
