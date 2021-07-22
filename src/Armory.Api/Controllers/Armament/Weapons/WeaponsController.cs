using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Weapons.Requests;
using Armory.Armament.Weapons.Application;
using Armory.Armament.Weapons.Application.CheckExists;
using Armory.Armament.Weapons.Application.Create;
using Armory.Armament.Weapons.Application.Find;
using Armory.Armament.Weapons.Application.SearchAll;
using Armory.Armament.Weapons.Application.Update;
using Armory.Armament.Weapons.Domain;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;
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
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IMapper _mapper;

        public WeaponsController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterWeapon([FromBody] CreateWeaponRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateWeaponCommand>(request);
                await _commandBus.Dispatch(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponResponse>>> GetWeapons()
        {
            var weapons = await _queryBus.Ask<IEnumerable<WeaponResponse>>(new SearchAllWeaponsQuery());
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
            var weapon = await _queryBus.Ask<WeaponResponse>(new FindWeaponQuery(code));
            if (weapon != null)
            {
                return Ok(weapon);
            }

            return WeaponNotFound(code);
        }

        [HttpGet("Exists/{code}")]
        public async Task<ActionResult<bool>> CheckExists(string code)
        {
            var exists = await _queryBus.Ask<bool>(new CheckWeaponExistsQuery(code));
            return Ok(exists);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateWeapon(string code, [FromBody] UpdateWeaponRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateWeaponCommand>(request);
                await _commandBus.Dispatch(command);
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
