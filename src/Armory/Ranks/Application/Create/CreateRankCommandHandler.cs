using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Ranks.Application.Create
{
    public class CreateRankCommandHandler : CommandHandler<CreateRankCommand>
    {
        private readonly RankCreator _creator;

        public CreateRankCommandHandler(RankCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreateRankCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request);
        }
    }
}
