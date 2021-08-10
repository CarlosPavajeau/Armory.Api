using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Squadron.Requests;
using Armory.Squadrons.Application;
using Armory.Squadrons.Application.CheckExists;
using Armory.Squadrons.Application.Create;
using Armory.Squadrons.Application.Find;
using Armory.Squadrons.Application.SearchAll;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Squadron
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class SquadronsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SquadronsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSquadron([FromBody] CreateSquadronRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateSquadronCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckSquadronExistsQuery(request.Code));
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("SquadronAlreadyRegistered",
                    $"Ya existe una escuadrilla con el código '{request.Code}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadronResponse>>> GetSquadrons()
        {
            var response = await _mediator.Send(new SearchAllSquadronsQuery());
            return Ok(response);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<SquadronResponse>> GetSquadron(string code)
        {
            var response = await _mediator.Send(new FindSquadronQuery(code));
            if (response != null)
            {
                return Ok(response);
            }

            ModelState.AddModelError("SquadronNotFound",
                $"La escuadrilla con el código '{code}' no se encuentra registrado.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("Exists/{code}")]
        public async Task<ActionResult<bool>> CheckExists(string code)
        {
            var exists = await _mediator.Send(new CheckSquadronExistsQuery(code));
            return Ok(exists);
        }
    }
}
