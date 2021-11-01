using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Fireteams.Requests;
using Armory.Fireteams.Application;
using Armory.Fireteams.Application.CheckExists;
using Armory.Fireteams.Application.Create;
using Armory.Fireteams.Application.Find;
using Armory.Fireteams.Application.SearchAll;
using Armory.Fireteams.Application.SearchAllByFlight;
using Armory.Fireteams.Application.UpdateCommander;
using Armory.Fireteams.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Fireteams
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class FireteamsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FireteamsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterFireteam([FromBody] CreateFireteamRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateFireteamCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckFireteamExistsQuery(request.Code));
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("FireteamAlreadyRegistered",
                    $"Ya existe una escuadra con el código '{request.Code}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FireteamResponse>>> GetFireteams()
        {
            var response = await _mediator.Send(new SearchAllFireteamsQuery());
            return Ok(response);
        }

        [HttpGet("ByFlight/{flightCode}")]
        public async Task<ActionResult<IEnumerable<FireteamResponse>>> GetFireteamsByFlight(string flightCode)
        {
            var response = await _mediator.Send(new SearchAllFireteamsByFlightQuery(flightCode));
            return Ok(response);
        }

        private NotFoundObjectResult FireTeamNotFound(string code)
        {
            ModelState.AddModelError("FireteamNotFound",
                $"El escuadrón con el código '{code}' no se encuentra registrado.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<FireteamResponse>> GetFireteam(string code)
        {
            var response = await _mediator.Send(new FindFireteamQuery(code));
            if (response != null)
            {
                return Ok(response);
            }

            return FireTeamNotFound(code);
        }

        [HttpGet("Exists/{code}")]
        public async Task<ActionResult<bool>> CheckExists(string code)
        {
            var exists = await _mediator.Send(new CheckFireteamExistsQuery(code));
            return Ok(exists);
        }

        [HttpPut("Commander")]
        public async Task<ActionResult> UpdateCommander([FromBody] UpdateFireTeamCommanderRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateFireTeamCommanderCommand>(request);
                await _mediator.Send(command);
            }
            catch (FireTeamNotFound)
            {
                return FireTeamNotFound(request.Code);
            }

            return Ok();
        }
    }
}
