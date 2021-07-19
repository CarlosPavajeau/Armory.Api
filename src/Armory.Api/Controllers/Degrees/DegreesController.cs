using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Degrees.Requests;
using Armory.Degrees.Application;
using Armory.Degrees.Application.Create;
using Armory.Degrees.Application.Find;
using Armory.Degrees.Application.SearchAll;
using Armory.Degrees.Application.SearchAllByRank;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Degrees
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class DegreesController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IMapper _mapper;

        public DegreesController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDegree([FromBody] CreateDegreeRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateDegreeCommand>(request);
                await _commandBus.Dispatch(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DegreeResponse>>> GetDegrees()
        {
            var degrees = await _queryBus.Ask<IEnumerable<DegreeResponse>>(new SearchAllDegreesQuery());
            return Ok(degrees);
        }

        [HttpGet("ByRank/{rankId:int}")]
        public async Task<ActionResult<IEnumerable<DegreeResponse>>> GetDegreesByRank(int rankId)
        {
            var degrees = await _queryBus.Ask<IEnumerable<DegreeResponse>>(new SearchAllDegreesByRankQuery(rankId));
            return Ok(degrees);
        }

        private NotFoundObjectResult DegreeNotFound(int id)
        {
            ModelState.AddModelError("DegreeNotFound",
                $"No se encontró ningun grado con el código '{id}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DegreeResponse>> GetDegree(int id)
        {
            var degree = await _queryBus.Ask<DegreeResponse>(new FindDegreeQuery(id));
            if (degree != null)
            {
                return Ok(degree);
            }

            return DegreeNotFound(id);
        }
    }
}
