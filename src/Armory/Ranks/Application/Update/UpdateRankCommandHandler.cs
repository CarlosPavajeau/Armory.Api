using System.Threading;
using System.Threading.Tasks;
using Armory.Ranks.Application.Find;
using Armory.Ranks.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Ranks.Application.Update
{
    public class UpdateRankCommandHandler : CommandHandler<UpdateRankCommand>
    {
        private readonly RankFinder _finder;
        private readonly RankUpdater _updater;

        public UpdateRankCommandHandler(RankFinder finder, RankUpdater updater)
        {
            _finder = finder;
            _updater = updater;
        }

        protected override async Task Handle(UpdateRankCommand request, CancellationToken cancellationToken)
        {
            var rank = await _finder.Find(request.Id, false);
            if (rank is null)
            {
                throw new RankNotFoundException();
            }

            await _updater.Update(rank, request.Name);
        }
    }
}
