using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Armory.Api.Controllers.People.Requests;
using Armory.People.Application;
using Armory.People.Application.Create;
using Armory.People.Application.Delete;
using Armory.People.Application.SearchAll;
using Armory.People.Application.SearchAllByRole;
using Armory.People.Application.SearchByArmoryUserId;
using Armory.People.Application.SearchById;
using Armory.People.Application.Update;
using Armory.People.Domain;
using Armory.Shared.Domain.Bus.Command;
using Armory.Shared.Domain.Bus.Query;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        public async Task<IActionResult> RegisterPerson([FromBody] CreatePersonRequest request)
        {
            try
            {
                await _commandBus.Dispatch(new CreatePersonCommand(request.Id, request.FirstName, request.SecondName,
                    request.LastName, request.SecondLastName, request.ArmoryUserId));
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                throw;
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
            var response = await _queryBus.Ask<PersonResponse>(new SearchPersonByIdQuery(id));
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
