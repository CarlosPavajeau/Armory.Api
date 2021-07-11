using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Armament.Explosives.Requests;
using Armory.Armament.Explosives.Application;
using Armory.Armament.Explosives.Application.Create;
using Armory.Armament.Explosives.Application.Find;
using Armory.Armament.Explosives.Application.SearchAll;
using Armory.Armament.Explosives.Application.Update;
using Armory.Armament.Explosives.Domain;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Armament.Explosives
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ExplosivesController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IMapper _mapper;

        public ExplosivesController(ICommandBus commandBus, IQueryBus queryBus, IMapper mapper)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterExplosive([FromBody] CreateExplosiveRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateExplosiveCommand>(request);
                await _commandBus.Dispatch(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExplosiveResponse>>> GetExplosives()
        {
            var explosives = await _queryBus.Ask<IEnumerable<ExplosiveResponse>>(new SearchAllExplosivesQuery());
            return Ok(explosives);
        }

        private NotFoundObjectResult ExplosiveNotFound(string code)
        {
            ModelState.AddModelError("ExplosiveNotFound",
                $"No se encontró ningún explosivo con el código '{code}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ExplosiveResponse>> GetExplosive(string code)
        {
            var explosive = await _queryBus.Ask<ExplosiveResponse>(new FindExplosiveQuery(code));
            if (explosive != null)
            {
                return Ok(explosive);
            }

            return ExplosiveNotFound(code);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateExplosive(string code, [FromBody] UpdateExplosiveRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateExplosiveCommand>(request);
                await _commandBus.Dispatch(command);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (ExplosiveNotFound)
            {
                return ExplosiveNotFound(code);
            }

            return Ok();
        }
    }
}
