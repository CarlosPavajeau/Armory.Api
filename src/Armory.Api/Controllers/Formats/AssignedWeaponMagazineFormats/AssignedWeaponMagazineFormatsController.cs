using System.IO;
using System.Threading.Tasks;
using Armory.Api.Controllers.Formats.AssignedWeaponMagazineFormats.Requests;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Create;
using Armory.Formats.AssignedWeaponMagazineFormats.Application.Generate;
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
        public async Task<ActionResult<MemoryStream>> RegisterAssignedWeaponMagazineFormat(
            [FromBody] CreateAssignedWeaponMagazineFormatRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateAssignedWeaponMagazineFormatCommand>(request);
                var formatId = await _mediator.Send(command);
                var stream = await _mediator.Send(new GenerateAssignedWeaponMagazineFormatQuery(formatId));

                stream.Position = 0;
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "format.xlsx");
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<MemoryStream>> Get()
        {
            var stream = await _mediator.Send(new GenerateAssignedWeaponMagazineFormatQuery(1));

            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "format.xlsx");
        }
    }
}
