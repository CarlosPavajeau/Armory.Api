using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Squadron.Application.Create
{
    public class CreateSquadronCommandHandler : ICommandHandler<CreateSquadronCommand>
    {
        private readonly SquadronCreator _creator;

        public CreateSquadronCommandHandler(SquadronCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateSquadronCommand command)
        {
            await _creator.Create(command.Code, command.Name, command.ArmoryUserId);
        }
    }
}
