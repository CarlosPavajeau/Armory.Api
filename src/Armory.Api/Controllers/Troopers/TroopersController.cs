using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Troopers.Requests;
using Armory.Troopers.Application;
using Armory.Troopers.Application.CheckExists;
using Armory.Troopers.Application.Create;
using Armory.Troopers.Application.Find;
using Armory.Troopers.Application.SearchAll;
using Armory.Troopers.Application.SearchAllByFireteam;
using Armory.Troopers.Application.Update;
using Armory.Troopers.Application.UpdateFireTeam;
using Armory.Troopers.Domain;
using AutoMapper;
using MediatR;
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
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TroopersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTroop([FromBody] CreateTroopRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateTroopCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckTroopExistsQuery(request.Id));
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
            var troopers = await _mediator.Send(new SearchAllTroopersQuery());
            return Ok(troopers);
        }

        [HttpGet("ByFireteam/{fireteamCode}")]
        public async Task<ActionResult<IEnumerable<TroopResponse>>> GetTroopersByFireteam(string fireteamCode)
        {
            var troopers = await _mediator.Send(new SearchAllTroopersByFireteamQuery(fireteamCode));
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
            var troop = await _mediator.Send(new FindTroopQuery(id));
            if (troop != null)
            {
                return Ok(troop);
            }

            return TroopNotFound(id);
        }

        [HttpGet("Exists/{id}")]
        public async Task<ActionResult<bool>> CheckExists(string id)
        {
            var exists = await _mediator.Send(new CheckTroopExistsQuery(id));
            return Ok(exists);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTroop(string id, [FromBody] UpdateTroopRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateTroopCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (TroopNotFoundException)
            {
                return TroopNotFound(id);
            }

            return Ok();
        }

        [HttpPut("FireTeam")]
        public async Task<ActionResult> UpdateFireTeam([FromBody] UpdateTroopFireTeamRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateTroopFireTeamCommand>(request);
                await _mediator.Send(command);
            }
            catch (TroopNotFoundException)
            {
                return TroopNotFound(request.Id);
            }

            return Ok();
        }
    }
}
