using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Squads.Requests;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Squads.Application;
using Armory.Squads.Application.CheckExists;
using Armory.Squads.Application.Create;
using Armory.Squads.Application.Find;
using Armory.Squads.Application.SearchAll;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public SquadsController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSquad([FromBody] CreateSquadRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateSquadCommand>(request);
                await _commandBus.Dispatch(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _queryBus.Ask<bool>(new CheckSquadExistsQuery(request.Code));
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("SquadAlreadyRegistered",
                    $"Ya existe una escuadra con el código '{request.Code}'");
                return Conflict(new ValidationProblemDetails(ModelState));
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
            var response = await _queryBus.Ask<SquadResponse>(new FindSquadQuery(code));
            if (response != null)
            {
                return Ok(response);
            }

            ModelState.AddModelError("SquadNotFound",
                $"El escuadrón con el código '{code}' no se encuentra registrado.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("Exists/{code}")]
        public async Task<ActionResult<bool>> CheckExists(string code)
        {
            var exists = await _queryBus.Ask<bool>(new CheckSquadExistsQuery(code));
            return Ok(exists);
        }
    }
}
