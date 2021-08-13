using System.IO;
using System.Threading.Tasks;
using Armory.Api.Controllers.Formats.AssignedWeaponMagazineFormats.Requests;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.AddItem;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Create;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Generate;
using Armory.Formats.AssignedWeaponMagazineFormats.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Formats.AssignedWeaponMagazineFormats
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AssignedWeaponMagazineFormatsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AssignedWeaponMagazineFormatsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> RegisterAssignedWeaponMagazineFormat(
            [FromBody] CreateAssignedWeaponMagazineFormatRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateAssignedWeaponMagazineFormatCommand>(request);
                var formatId = await _mediator.Send(command);

                return Ok(formatId);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
        }

        private NotFoundObjectResult AssignedWeaponMagazineFormatNotFound(int id)
        {
            ModelState.AddModelError("AssignedWeaponMagazineFormatNotFound",
                $"No se encontró ningun formato con el código '{id}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("AddItem/{id:int}")]
        public async Task<IActionResult> AddAssignedWeaponMagazineFormatItem(int id,
            [FromBody] AddAssignedWeaponMagazineFormatItemRequest request)
        {
            try
            {
                var command = _mapper.Map<AddAssignedWeaponMagazineFormatItemCommand>(request);
                await _mediator.Send(command);
            }
            catch (AssignedWeaponMagazineFormatNotFound)
            {
                return AssignedWeaponMagazineFormatNotFound(id);
            }

            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Stream>> GenerateFormat(int id)
        {
            try
            {
                var stream = await _mediator.Send(new GenerateAssignedWeaponMagazineFormatQuery(id));

                stream.Position = 0;
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "format.xlsx");
            }
            catch (AssignedWeaponMagazineFormatNotFound)
            {
                return AssignedWeaponMagazineFormatNotFound(id);
            }
        }
    }
}