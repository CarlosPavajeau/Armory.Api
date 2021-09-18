using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.Flights.Requests;
using Armory.Flights.Application;
using Armory.Flights.Application.CheckExists;
using Armory.Flights.Application.Create;
using Armory.Flights.Application.Find;
using Armory.Flights.Application.SearchAll;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.Flights
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FlightsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterFlight([FromBody] CreateFlightRequest request)
        {
            try
            {
                var command = _mapper.Map<CreateFlightCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                var exists = await _mediator.Send(new CheckFlightExistsQuery(request.Code));
                if (!exists)
                {
                    throw;
                }

                ModelState.AddModelError("FlightAlreadyRegistered",
                    $"Ya existe una escuadrilla con el código '{request.Code}'");
                return Conflict(new ValidationProblemDetails(ModelState));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightResponse>>> GetFlights()
        {
            var response = await _mediator.Send(new SearchAllFlightsQuery());
            return Ok(response);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<FlightResponse>> GetFlight(string code)
        {
            var response = await _mediator.Send(new FindFlightQuery(code));
            if (response != null)
            {
                return Ok(response);
            }

            ModelState.AddModelError("FlightNotFound",
                $"La escuadrilla con el código '{code}' no se encuentra registrado.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("Exists/{code}")]
        public async Task<ActionResult<bool>> CheckExists(string code)
        {
            var exists = await _mediator.Send(new CheckFlightExistsQuery(code));
            return Ok(exists);
        }
    }
}
