using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Explosives.Requests;
using Armory.Armament.Explosives.Application;
using Armory.Armament.Explosives.Application.CheckExists;
using Armory.Armament.Explosives.Application.Create;
using Armory.Armament.Explosives.Application.Find;
using Armory.Armament.Explosives.Application.SearchAll;
using Armory.Armament.Explosives.Application.SearchAllByFlight;
using Armory.Armament.Explosives.Application.Update;
using Armory.Armament.Explosives.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Armament.Explosives
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ExplosivesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ExplosivesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterExplosive([FromBody] CreateExplosiveRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateExplosiveCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckExplosiveExistsQuery(request.Serial));
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("ExplosiveAlreadyRegistered",
                    $"Ya existe un explosivo con el número de serie '{request.Serial}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExplosiveResponse>>> GetExplosives()
        {
            var explosives = await _mediator.Send(new SearchAllExplosivesQuery());
            return Ok(explosives);
        }

        [HttpGet("ByFlight/{flightCode}")]
        public async Task<ActionResult<IEnumerable<ExplosiveResponse>>> GetExplosivesByFlight(string flightCode)
        {
            var explosives = await _mediator.Send(new SearchAllExplosivesByFlightQuery { FlightCode = flightCode });
            return Ok(explosives);
        }

        private NotFoundObjectResult ExplosiveNotFound(string code)
        {
            ModelState.AddModelError("ExplosiveNotFound",
                $"No se encontró ningún explosivo con el código '{code}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ExplosiveResponse>> GetExplosive(string code)
        {
            var explosive = await _mediator.Send(new FindExplosiveQuery(code));
            if (explosive != null)
            {
                return Ok(explosive);
            }

            return ExplosiveNotFound(code);
        }

        [HttpGet("Exists/{code}")]
        public async Task<ActionResult<bool>> CheckExists(string code)
        {
            var exists = await _mediator.Send(new CheckExplosiveExistsQuery(code));
            return Ok(exists);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateExplosive(string code, [FromBody] UpdateExplosiveRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateExplosiveCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (ExplosiveNotFoundException)
            {
                return ExplosiveNotFound(code);
            }

            return Ok();
        }
    }
}
