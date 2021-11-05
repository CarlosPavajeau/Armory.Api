using System.Threading;
using System.Threading.Tasks;
using Armory.Degrees.Application.Find;
using Armory.Degrees.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Degrees.Application.Update
{
    public class UpdateDegreeCommandHandler : CommandHandler<UpdateDegreeCommand>
    {
        private readonly DegreeFinder _finder;
        private readonly DegreeUpdater _updater;

        public UpdateDegreeCommandHandler(DegreeFinder finder, DegreeUpdater updater)
        {
            _finder = finder;
            _updater = updater;
        }

        protected override async Task Handle(UpdateDegreeCommand request, CancellationToken cancellationToken)
        {
            var degree = await _finder.Find(request.Id, false);
            if (degree is null)
            {
                throw new DegreeNotFoundException();
            }

            await _updater.Update(degree, request.Name);
        }
    }
}
