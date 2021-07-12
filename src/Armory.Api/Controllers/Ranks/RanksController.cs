using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Ranks.Requests;
using Armory.Ranks.Application;
using Armory.Ranks.Application.Create;
using Armory.Ranks.Application.Find;
using Armory.Ranks.Application.SearchAll;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;
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
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IMapper _mapper;

        public RanksController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterRank([FromBody] CreateRankRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateRankCommand>(request);
                await _commandBus.Dispatch(command);
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
            var ranks = await _queryBus.Ask<IEnumerable<RankResponse>>(new SearchAllRanksQuery());
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
            var rank = await _queryBus.Ask<RankResponse>(new FindRankQuery(id));
            if (rank != null)
            {
                return Ok(rank);
            }

            return RankNotFound(id);
        }
    }
}
