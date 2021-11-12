using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Equipments.Requests;
using Armory.Armament.Equipments.Application;
using Armory.Armament.Equipments.Application.CheckExists;
using Armory.Armament.Equipments.Application.Create;
using Armory.Armament.Equipments.Application.Find;
using Armory.Armament.Equipments.Application.SearchAll;
using Armory.Armament.Equipments.Application.SearchAllByFlight;
using Armory.Armament.Equipments.Application.Update;
using Armory.Armament.Equipments.Domain;
using AutoMapper;
using MediatR;
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
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EquipmentsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterEquipment([FromBody] CreateEquipmentRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateEquipmentCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckEquipmentExistsQuery(request.Serial));
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("EquipmentAlreadyRegistered",
                    $"Ya existe un equipo especial o accesorio con el número de serie '{request.Serial}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentResponse>>> GetEquipments()
        {
            var equipments = await _mediator.Send(new SearchAllEquipmentsQuery());
            return Ok(equipments);
        }

        [HttpGet("ByFlight/{flightCode}")]
        public async Task<ActionResult<IEnumerable<EquipmentResponse>>> GetEquipmentsByFlight(string flightCode)
        {
            var equipments = await _mediator.Send(new SearchAllEquipmentsByFlightQuery { FlightCode = flightCode });
            return Ok(equipments);
        }

        private NotFoundObjectResult EquipmentNotFound(string serial)
        {
            ModelState.AddModelError("EquipmentNotFound",
                $"No se encontró ningun equipo especial o accesorio con el serial '{serial}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{serial}")]
        public async Task<ActionResult<EquipmentResponse>> GetEquipment(string serial)
        {
            var equipment = await _mediator.Send(new FindEquipmentQuery(serial));
            if (equipment != null)
            {
                return Ok(equipment);
            }

            return EquipmentNotFound(serial);
        }

        [HttpGet("Exists/{serial}")]
        public async Task<ActionResult<bool>> CheckExists(string serial)
        {
            var exists = await _mediator.Send(new CheckEquipmentExistsQuery(serial));
            return Ok(exists);
        }

        [HttpPut("{serial}")]
        public async Task<IActionResult> UpdateEquipment(string serial, [FromBody] UpdateEquipmentRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateEquipmentCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (EquipmentNotFoundException)
            {
                return EquipmentNotFound(serial);
            }

            return Ok();
        }
    }
}
