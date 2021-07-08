using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squads.Application.Create
{
    public class CreateSquadCommandHandler : ICommandHandler<CreateSquadCommand>
    {
        private readonly SquadCreator _creator;

        public CreateSquadCommandHandler(SquadCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateSquadCommand command)
        {
            await _creator.Create(command.Code, command.Name, command.PersonId, command.SquadronCode);
        }
    }
}
