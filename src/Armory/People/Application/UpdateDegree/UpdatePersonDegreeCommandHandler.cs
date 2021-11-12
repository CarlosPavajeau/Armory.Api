using System.Threading;
using System.Threading.Tasks;
using Armory.People.Application.Find;
using Armory.People.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.UpdateDegree
{
    public class UpdatePersonDegreeCommandHandler : CommandHandler<UpdatePersonDegreeCommand>
    {
        private readonly PersonFinder _finder;
        private readonly PersonDegreeUpdater _updater;

        public UpdatePersonDegreeCommandHandler(PersonFinder finder, PersonDegreeUpdater updater)
        {
            _finder = finder;
            _updater = updater;
        }

        protected override async Task Handle(UpdatePersonDegreeCommand request, CancellationToken cancellationToken)
        {
            var person = await _finder.Find(request.Id, false);
            if (person == null)
            {
                throw new PersonNotFoundException();
            }

            await _updater.UpdateDegree(person, request.DegreeId);
        }
    }
}
