using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Create
{
    public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand>
    {
        private readonly PersonCreator _creator;

        public CreatePersonCommandHandler(PersonCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreatePersonCommand command)
        {
            await _creator.Create(command.Id, command.FirstName, command.SecondName, command.LastName,
                command.SecondLastName, command.Email, command.PhoneNumber, command.RoleName);
        }
    }
}
