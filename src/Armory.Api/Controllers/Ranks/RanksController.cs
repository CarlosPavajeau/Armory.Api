using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Ranks.Requests;
using Armory.Ranks.Application;
using Armory.Ranks.Application.Create;
using Armory.Ranks.Application.Find;
using Armory.Ranks.Application.SearchAll;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Ranks
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class RanksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RanksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterRank([FromBody] CreateRankRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateRankCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RankResponse>>> GetRanks()
        {
            var ranks = await _mediator.Send(new SearchAllRanksQuery());
            return Ok(ranks);
        }

        private NotFoundObjectResult RankNotFound(int id)
        {
            ModelState.AddModelError("RankNotFound",
                $"No se encontró ningun rango con el código '{id}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RankResponse>> GetRank(int id)
        {
            var rank = await _mediator.Send(new FindRankQuery(id));
            if (rank != null) return Ok(rank);

            return RankNotFound(id);
        }
    }
}
