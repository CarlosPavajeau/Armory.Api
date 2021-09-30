using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Weapons.Requests;
using Armory.Armament.Weapons.Application;
using Armory.Armament.Weapons.Application.CheckExists;
using Armory.Armament.Weapons.Application.Create;
using Armory.Armament.Weapons.Application.Find;
using Armory.Armament.Weapons.Application.GenerateQR;
using Armory.Armament.Weapons.Application.SearchAll;
using Armory.Armament.Weapons.Application.SearchAllByFlight;
using Armory.Armament.Weapons.Application.Update;
using Armory.Armament.Weapons.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Armament.Weapons
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WeaponsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WeaponsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterWeapon([FromBody] CreateWeaponRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateWeaponCommand>(request);
                var weaponSerial = await _mediator.Send(command);

                var stream = await _mediator.Send(new GenerateWeaponQrQuery(weaponSerial));
                stream.Position = 0;
                return File(stream, "application/octet-stream", $"{weaponSerial}.pdf");
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckWeaponExistsQuery(request.Serial));
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("WeaponAlreadyRegistered",
                    $"Ya existe un arma con el número de serie '{request.Serial}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponResponse>>> GetWeapons()
        {
            var weapons = await _mediator.Send(new SearchAllWeaponsQuery());
            return Ok(weapons);
        }

        [HttpGet("ByFlight/{flightCode}")]
        public async Task<ActionResult<IEnumerable<WeaponResponse>>> GetWeaponsByFlight(string flightCode)
        {
            var weapons = await _mediator.Send(new SearchAllWeaponsByFlightQuery { FlightCode = flightCode });
            return Ok(weapons);
        }

        private NotFoundObjectResult WeaponNotFound(string serial)
        {
            ModelState.AddModelError("WeaponNotFound",
                $"No se encontró ningun arma con el número de serie '{serial}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{serial}")]
        public async Task<ActionResult<WeaponResponse>> GetWeapon(string serial)
        {
            var weapon = await _mediator.Send(new FindWeaponQuery(serial));
            if (weapon != null)
            {
                return Ok(weapon);
            }

            return WeaponNotFound(serial);
        }

        [HttpGet("Exists/{serial}")]
        public async Task<ActionResult<bool>> CheckExists(string serial)
        {
            var exists = await _mediator.Send(new CheckWeaponExistsQuery(serial));
            return Ok(exists);
        }

        [HttpGet("[action]/{serial}")]
        public async Task<ActionResult> GenerateQr(string serial)
        {
            try
            {
                var stream = await _mediator.Send(new GenerateWeaponQrQuery(serial));
                stream.Position = 0;
                return File(stream, "application/octet-stream", $"{serial}.pdf");
            }
            catch (WeaponNotFound)
            {
                return WeaponNotFound(serial);
            }
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateWeapon(string code, [FromBody] UpdateWeaponRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateWeaponCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (WeaponNotFound)
            {
                return WeaponNotFound(code);
            }

            return Ok();
        }
    }
}
