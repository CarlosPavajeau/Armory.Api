using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Troopers.Requests;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Troopers.Application;
using Armory.Troopers.Application.CheckExists;
using Armory.Troopers.Application.Create;
using Armory.Troopers.Application.Find;
using Armory.Troopers.Application.SearchAll;
using Armory.Troopers.Application.Update;
using Armory.Troopers.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Troopers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TroopersController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IMapper _mapper;

        public TroopersController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTroop([FromBody] CreateTroopRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateTroopCommand>(request);
                await _commandBus.Dispatch(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _queryBus.Ask<bool>(new CheckTroopExistsQuery(request.Id));
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("TroopAlreadyRegistered",
                    $"Ya existe una tropa con la identificación '{request.Id}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TroopResponse>>> GetTroopers()
        {
            var troopers = await _queryBus.Ask<IEnumerable<TroopResponse>>(new SearchAllTroopersQuery());
            return Ok(troopers);
        }

        private NotFoundObjectResult TroopNotFound(string id)
        {
            ModelState.AddModelError("TroopNotFound",
                $"No se encontró ninguna tropa con el código '{id}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TroopResponse>> GetTroop(string id)
        {
            var troop = await _queryBus.Ask<TroopResponse>(new FindTroopQuery(id));
            if (troop != null)
            {
                return Ok(troop);
            }

            return TroopNotFound(id);
        }

        [HttpGet("Exists/{id}")]
        public async Task<ActionResult<bool>> CheckExists(string id)
        {
            var exists = await _queryBus.Ask<bool>(new CheckTroopExistsQuery(id));
            return Ok(exists);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTroop(string id, [FromBody] UpdateTroopRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateTroopCommand>(request);
                await _commandBus.Dispatch(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (TroopNotFound)
            {
                return TroopNotFound(id);
            }

            return Ok();
        }
    }
}
