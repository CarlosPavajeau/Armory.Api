using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Squads.Requests;
using Armory.Squads.Application;
using Armory.Squads.Application.CheckExists;
using Armory.Squads.Application.Create;
using Armory.Squads.Application.Find;
using Armory.Squads.Application.SearchAll;
using Armory.Squads.Domain;
using Armory.Squads.UpdateCommander;
using AutoMapper;
using MediatR;
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
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SquadsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSquad([FromBody] CreateSquadRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateSquadCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckSquadExistsQuery { SquadCode = request.Code });
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("SquadAlreadyRegistered",
                    $"Ya esxiste un escuadrón con el código '{request.Code}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadResponse>>> GetSquads()
        {
            var squads = await _mediator.Send(new SearchAllSquadsQuery());
            return Ok(squads);
        }

        private NotFoundObjectResult SquadNotFound(string code)
        {
            ModelState.AddModelError("SquadNotFound", $"No existe ningún escuadrón con el codigo '{code}'");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<SquadResponse>> GetSquad(string code)
        {
            var squad = await _mediator.Send(new FindSquadQuery { Code = code });
            if (squad != null)
            {
                return Ok(squad);
            }

            return SquadNotFound(code);
        }

        [HttpPut("Commander")]
        public async Task<ActionResult> UpdateCommander([FromBody] UpdateSquadCommanderRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateSquadCommanderCommand>(request);
                await _mediator.Send(command);
            }
            catch (SquadNotFoundException)
            {
                return SquadNotFound(request.Code);
            }

            return Ok();
        }
    }
}
