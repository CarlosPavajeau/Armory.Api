using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Degrees.Application.Create
{
    public class CreateDegreeCommandHandler : ICommandHandler<CreateDegreeCommand>
    {
        private readonly DegreeCreator _creator;

        public CreateDegreeCommandHandler(DegreeCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateDegreeCommand command)
        {
            await _creator.Create(command.Name, command.RankId);
        }
    }
}
