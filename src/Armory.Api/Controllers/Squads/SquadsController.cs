using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Squads.Requests;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Squads.Application;
using Armory.Squads.Application.Create;
using Armory.Squads.Application.SearchAll;
using Armory.Squads.Application.SearchByCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Squads
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class SquadsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public SquadsController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSquad([FromBody] CreateSquadRequest request)
        {
            try
            {
                await _commandBus.Dispatch(new CreateSquadCommand(request.Code, request.Name, request.PersonId,
                    request.SquadronCode));
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadResponse>>> GetSquads()
        {
            var response = await _queryBus.Ask<IEnumerable<SquadResponse>>(new SearchAllSquadsQuery());
            return Ok(response);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<SquadResponse>> GetSquad(string code)
        {
            var response = await _queryBus.Ask<SquadResponse>(new SearchSquadByCodeQuery(code));
            if (response != null)
            {
                return Ok(response);
            }

            ModelState.AddModelError("SquadNotFound",
                $"El escuadrón con el código '{code}' no se encuentra registrado.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }
    }
}
