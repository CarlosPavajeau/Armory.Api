using System.Threading.Tasks;
using Armory.Api.Controllers.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Requests;
using Armory.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats.Application.Create;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Formats.WarMaterialAndSpecialEquipmentAssignmentFormats
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WarMaterialAndSpecialEquipmentAssignmentFormatsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WarMaterialAndSpecialEquipmentAssignmentFormatsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterWarMaterialAndSpecialEquipmentAssignmentFormat(
            [FromBody] CreateWarMaterialAndSpecialEquipmentAssignmentFormatRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateWarMaterialAndSpecialEquipmentAssignmentFormatCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException e)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
