using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Armament.Explosives.Application.Create
{
    public class CreateExplosiveCommandHandler : ICommandHandler<CreateExplosiveCommand>
    {
        private readonly ExplosiveCreator _creator;

        public CreateExplosiveCommandHandler(ExplosiveCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateExplosiveCommand command)
        {
            await _creator.Create(command.Code, command.Type, command.Caliber, command.Mark, command.Lot,
                command.Series, command.QuantityAvailable);
        }
    }
}
