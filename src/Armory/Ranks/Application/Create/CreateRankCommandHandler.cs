using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Ranks.Application.Create
{
    public class CreateRankCommandHandler : ICommandHandler<CreateRankCommand>
    {
        private readonly RankCreator _creator;

        public CreateRankCommandHandler(RankCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateRankCommand command)
        {
            await _creator.Create(command.Name);
        }
    }
}
