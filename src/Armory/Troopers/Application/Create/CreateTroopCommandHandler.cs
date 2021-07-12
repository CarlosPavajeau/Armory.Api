using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Troopers.Application.Create
{
    public class CreateTroopCommandHandler : ICommandHandler<CreateTroopCommand>
    {
        private readonly TroopCreator _creator;

        public CreateTroopCommandHandler(TroopCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateTroopCommand command)
        {
            await _creator.Create(command.Id, command.FirstName, command.SecondName, command.LastName,
                command.SecondLastName, command.SquadCode, command.DegreeId);
        }
    }
}
