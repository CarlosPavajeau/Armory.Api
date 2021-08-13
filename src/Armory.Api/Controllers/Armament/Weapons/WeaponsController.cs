using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Weapons.Requests;
using Armory.Armament.Weapons.Application;
using Armory.Armament.Weapons.Application.CheckExists;
using Armory.Armament.Weapons.Application.Create;
using Armory.Armament.Weapons.Application.Find;
using Armory.Armament.Weapons.Application.GenerateQR;
using Armory.Armament.Weapons.Application.SearchAll;
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
        public async Task<ActionResult<FileStream>> RegisterWeapon([FromBody] CreateWeaponRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateWeaponCommand>(request);
                var weaponCode = await _mediator.Send(command);

                return CreatedAtAction(nameof(GenerateQr), new { Code = weaponCode });
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckWeaponExistsQuery(request.Code));
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("WeaponAlreadyRegistered",
                    $"Ya existe un arma con el código '{request.Code}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponResponse>>> GetWeapons()
        {
            var weapons = await _mediator.Send(new SearchAllWeaponsQuery());
            return Ok(weapons);
        }

        private NotFoundObjectResult WeaponNotFound(string code)
        {
            ModelState.AddModelError("WeaponNotFound",
                $"No se encontró ningun arma con el código '{code}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<WeaponResponse>> GetWeapon(string code)
        {
            var weapon = await _mediator.Send(new FindWeaponQuery(code));
            if (weapon != null)
            {
                return Ok(weapon);
            }

            return WeaponNotFound(code);
        }

        [HttpGet("Exists/{code}")]
        public async Task<ActionResult<bool>> CheckExists(string code)
        {
            var exists = await _mediator.Send(new CheckWeaponExistsQuery(code));
            return Ok(exists);
        }

        [HttpGet("QR/{code}")]
        public async Task<ActionResult<FileStream>> GenerateQr(string code)
        {
            try
            {
                var stream = await _mediator.Send(new GenerateWeaponQrQuery(code));
                stream.Position = 0;
                return File(stream, "application/octet-stream", $"{code}.pdf");
            }
            catch (WeaponNotFound)
            {
                return WeaponNotFound(code);
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
