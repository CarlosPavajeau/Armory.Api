using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.People.Requests;
using Armory.People.Application;
using Armory.People.Application.CheckExists;
using Armory.People.Application.Create;
using Armory.People.Application.Delete;
using Armory.People.Application.Find;
using Armory.People.Application.SearchAll;
using Armory.People.Application.SearchAllByRole;
using Armory.People.Application.SearchByArmoryUserId;
using Armory.People.Application.Update;
using Armory.People.Domain;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Armory.Users.Domain;
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
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public PeopleController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
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
                await _commandBus.Dispatch(new CreatePersonCommand(request.Id, request.FirstName, request.SecondName,
                    request.LastName, request.SecondLastName, request.Email, request.PhoneNumber, request.RoleName));
            }
            catch (DbUpdateException)
            {
                var personExists = await _queryBus.Ask<bool>(new CheckPersonExistsQuery(request.Id));
                if (!personExists)
                {
                    throw;
                }

                ModelState.AddModelError("PersonAlreadyRegistered",
                    $"Ya existe una persona con la identificación {request.Id}");
                return Conflict(new ValidationProblemDetails(ModelState));
            }
            catch (ArmoryUserNotCreated e)
            {
                return IdentityErrors(e.Errors);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetPeople()
        {
            var response = await _queryBus.Ask<IEnumerable<PersonResponse>>(new SearchAllPeopleQuery());
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
            var response = await _queryBus.Ask<PersonResponse>(new FindPersonQuery(id));
            if (response != null)
            {
                return Ok(response);
            }

            return PersonNotFound(id);
        }

        [HttpGet("ByRole/{role}")]
        public async Task<ActionResult<IEnumerable<PersonResponse>>> GetPeopleByRole(string role)
        {
            var response = await _queryBus.Ask<IEnumerable<PersonResponse>>(new SearchAllPeopleByRoleQuery(role));
            return Ok(response);
        }

        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<PersonResponse>> GetPersonByUserId(string userId)
        {
            var response = await _queryBus.Ask<PersonResponse>(new SearchPersonByArmoryUserIdQuery(userId));
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
                await _commandBus.Dispatch(new UpdatePersonCommand(id, request.FirstName, request.SecondName,
                    request.LastName, request.SecondLastName));
            }
            catch (PersonNotFound)
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
                await _commandBus.Dispatch(new DeletePersonCommand(id));
            }
            catch (PersonNotFound)
            {
                return PersonNotFound(id);
            }

            return Ok();
        }
    }
}
