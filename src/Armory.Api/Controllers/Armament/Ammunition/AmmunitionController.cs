using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Ammunition.Requests;
using Armory.Armament.Ammunition.Application;
using Armory.Armament.Ammunition.Application.CheckExists;
using Armory.Armament.Ammunition.Application.Create;
using Armory.Armament.Ammunition.Application.Find;
using Armory.Armament.Ammunition.Application.SearchAll;
using Armory.Armament.Ammunition.Application.Update;
using Armory.Armament.Ammunition.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Armament.Ammunition
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AmmunitionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AmmunitionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAmmunition([FromBody] CreateAmmunitionRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateAmmunitionCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckAmmunitionExistsQuery(request.Code));
                if (!exists) throw;

                ModelState.AddModelError("AmmunitionAlreadyRegistered",
                    $"Ya existe una munición con el código '{request.Code}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmmunitionResponse>>> GetAmmunition()
        {
            var ammunition = await _mediator.Send(new SearchAllAmmunitionQuery());
            return Ok(ammunition);
        }

        private NotFoundObjectResult AmmunitionNotFound(string code)
        {
            ModelState.AddModelError("AmmunitionNotFound",
                $"No se encontró ninguna munición con el código '{code}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<AmmunitionResponse>> GetAmmunition(string code)
        {
            var ammunition = await _mediator.Send(new FindAmmunitionQuery(code));
            if (ammunition != null) return Ok(ammunition);

            return AmmunitionNotFound(code);
        }

        [HttpGet("Exists/{code}")]
        public async Task<ActionResult<bool>> CheckExists(string code)
        {
            var exists = await _mediator.Send(new CheckAmmunitionExistsQuery(code));
            return Ok(exists);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateAmmunition(string code, [FromBody] UpdateAmmunitionRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateAmmunitionCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (AmmunitionNotFound)
            {
                return AmmunitionNotFound(code);
            }

            return Ok();
        }
    }
}
