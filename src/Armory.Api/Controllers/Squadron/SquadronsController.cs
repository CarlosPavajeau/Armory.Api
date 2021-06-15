using System;
using System.Threading.Tasks;
using Armory.Api.Controllers.Squadron.Requests;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Squadron.Application.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Armory.Api.Controllers.Squadron
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class SquadronsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public SquadronsController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSquadron([FromBody] CreateSquadronRequest request)
        {
            try
            {
                await _commandBus.Dispatch(new CreateSquadronCommand(request.Code, request.Name, request.ArmoryUserId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }
    }
}
