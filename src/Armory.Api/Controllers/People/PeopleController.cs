using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.People.Requests;
using Armory.People.Application;
using Armory.People.Application.CheckExists;
using Armory.People.Application.Create;
using Armory.People.Application.Delete;
using Armory.People.Application.Find;
using Armory.People.Application.SearchAll;
using Armory.People.Application.SearchAllByRank;
using Armory.People.Application.SearchAllByRole;
using Armory.People.Application.SearchByArmoryUserId;
using Armory.People.Application.Update;
using Armory.People.Application.UpdateDegree;
using Armory.People.Domain;
using Armory.Users.Application.CheckExists;
using Armory.Users.Domain;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Armory.Api.Controllers.People
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PeopleController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private IActionResult IdentityErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPerson([FromBody] CreatePersonRequest request)
        {
            try
            {
                var command = _mapper.Map<CreatePersonCommand>(request);
                await _mediator.Send(command);
            }
            catch (DbUpdateException)
            {
                var personExists = await _mediator.Send(new CheckPersonExistsQuery(request.Id));
                if (!personExists)
                {
                    var userExists =
                        await _mediator.Send(new CheckArmoryUserExistsQuery(request.Email, request.PhoneNumber));
                    if (!userExists)
                    {
                        throw;
                    }
                }

                ModelState.AddModelError("PersonAlreadyRegistered",
                    "Ya existe una persona con los datos digitados. Verifique identificación, email y teléfono");
                return Conflict(new ValidationProblemDetails(ModelState));
            }
            catch (ArmoryUserNotCreatedException e)
            {
                return IdentityErrors(e.Errors);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetPeople()
        {
            var response = await _mediator.Send(new SearchAllPeopleQuery());
            return Ok(response);
        }

        private NotFoundObjectResult PersonNotFound(string id)
        {
            ModelState.AddModelError("PersonNotFound",
                $"No se encontró ninguna persona con la identificación '{id}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> GetPerson(string id)
        {
            var response = await _mediator.Send(new FindPersonQuery(id));
            if (response != null)
            {
                return Ok(response);
            }

            return PersonNotFound(id);
        }

        [HttpGet("ByRole/{role}")]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetPeopleByRole(string role)
        {
            var response = await _mediator.Send(new SearchAllPeopleByRoleQuery(role));
            return Ok(response);
        }

        [HttpGet("ByRank/{rankName}")]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetPeopleByRank(string rankName)
        {
            var response = await _mediator.Send(new SearchAllPeopleByRankQuery { RankName = rankName });
            return Ok(response);
        }

        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<PersonResponse>> GetPersonByUserId(string userId)
        {
            var response = await _mediator.Send(new SearchPersonByArmoryUserIdQuery(userId));
            if (response != null)
            {
                return Ok(response);
            }

            ModelState.AddModelError("PersonNotFound",
                $"No se encontró ninguna persona con el id de usuario '{userId}'.");
            return NotFound(new ValidationProblemDetails(ModelState));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(string id, [FromBody] UpdatePersonRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdatePersonCommand>(request);
                await _mediator.Send(command);
            }
            catch (PersonNotFoundException)
            {
                return PersonNotFound(id);
            }

            return Ok();
        }

        [HttpPut("ChangeDegree/{id}")]
        public async Task<IActionResult> UpdatePersonDegree(string id, [FromBody] UpdatePersonDegreeRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdatePersonDegreeCommand>(request);
                await _mediator.Send(command);
            }
            catch (PersonNotFoundException)
            {
                return PersonNotFound(id);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(string id)
        {
            try
            {
                await _mediator.Send(new DeletePersonCommand(id));
            }
            catch (PersonNotFoundException)
            {
                return PersonNotFound(id);
            }

            return Ok();
        }
    }
}
