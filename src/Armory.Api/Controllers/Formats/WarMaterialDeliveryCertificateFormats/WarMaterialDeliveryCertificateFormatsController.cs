using System.IO;
using System.Threading.Tasks;
using Armory.Api.Controllers.Formats.WarMaterialDeliveryCertificateFormats.Requests;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Create;
using Armory.Formats.WarMaterialDeliveryCertificateFormats.Application.Generate;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Formats.WarMaterialDeliveryCertificateFormats
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WarMaterialDeliveryCertificateFormatsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WarMaterialDeliveryCertificateFormatsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<FileStream>> RegisterWarMaterialDeliveryCertificateFormat(
            [FromBody] CreateWarMaterialDeliveryCertificateFormatRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateWarMaterialDeliveryCertificateFormatCommand>(request);
                var formatId = await _mediator.Send(command);
                var stream = await _mediator.Send(new GenerateWarMaterialDeliveryCertificateFormatQuery(formatId));

                stream.Position = 0;
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "format.xlsx");
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
        }
    }
}
