using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Equipments.Requests;
using Armory.Armament.Equipments.Application;
using Armory.Armament.Equipments.Application.Create;
using Armory.Armament.Equipments.Application.Find;
using Armory.Armament.Equipments.Application.SearchAll;
using Armory.Armament.Equipments.Application.Update;
using Armory.Armament.Equipments.Domain;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Armament.Equipments
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class EquipmentsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IMapper _mapper;

        public EquipmentsController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterEquipment([FromBody] CreateEquipmentRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateEquipmentCommand>(request);
                await _commandBus.Dispatch(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentResponse>>> GetEquipments()
        {
            var equipments = await _queryBus.Ask<IEnumerable<EquipmentResponse>>(new SearchAllEquipmentsQuery());
            return Ok(equipments);
        }

        private NotFoundObjectResult EquipmentNotFound(string code)
        {
            ModelState.AddModelError("EquipmentNotFound",
                $"No se encontró ningun equipo especial o accesorio con el código '{code}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<EquipmentResponse>> GetEquipment(string code)
        {
            var equipment = await _queryBus.Ask<EquipmentResponse>(new SearchEquipmentByCodeQuery(code));
            if (equipment != null)
            {
                return Ok(equipment);
            }

            return EquipmentNotFound(code);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateEquipment(string code, [FromBody] UpdateEquipmentRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateEquipmentCommand>(request);
                await _commandBus.Dispatch(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (EquipmentNotFound)
            {
                return EquipmentNotFound(code);
            }

            return Ok();
        }
    }
}
