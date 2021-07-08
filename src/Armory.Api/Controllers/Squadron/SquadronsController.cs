using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Squadron.Requests;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Squadrons.Application;
using Armory.Squadrons.Application.Create;
using Armory.Squadrons.Application.SearchAll;
using Armory.Squadrons.Application.SearchByCode;
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
                await _commandBus.Dispatch(new CreateSquadronCommand(request.Code, request.Name, request.PersonId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadronResponse>>> GetSquadrons()
        {
            var response = await _queryBus.Ask<IEnumerable<SquadronResponse>>(new SearchAllSquadronsQuery());
            return Ok(response);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<SquadronResponse>> GetSquadron(string code)
        {
            var response = await _queryBus.Ask<SquadronResponse>(new SearchSquadronByCodeQuery(code));
            if (response != null)
            {
                return Ok(response);
            }

            ModelState.AddModelError("SquadronNotFound",
                $"La escuadrilla con el código '{code}' no se encuentra registrado.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }
    }
}
