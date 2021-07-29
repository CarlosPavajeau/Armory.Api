using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using Armory.Troopers.Application.Find;
using Armory.Troopers.Domain;

namespace Armory.Troopers.Application.Update
{
    public class UpdateTroopCommandHandler : CommandHandler<UpdateTroopCommand>
    {
        private readonly TroopUpdater _updater;
        private readonly TroopFinder _finder;

        public UpdateTroopCommandHandler(TroopUpdater updater, TroopFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        protected override async Task Handle(UpdateTroopCommand request, CancellationToken cancellationToken)
        {
            var troop = await _finder.Find(request.Id);
            if (troop == null)
            {
                throw new TroopNotFound();
            }

            await _updater.Update(troop, request.FirstName, request.SecondName, request.LastName,
                request.SecondLastName);
        }
    }
}
