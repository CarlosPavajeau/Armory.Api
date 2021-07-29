using System.Threading;
using System.Threading.Tasks;
using Armory.People.Application.Find;
using Armory.People.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Update
{
    public class UpdatePersonCommandHandler : CommandHandler<UpdatePersonCommand>
    {
        private readonly PersonUpdater _updater;
        private readonly PersonFinder _finder;

        public UpdatePersonCommandHandler(PersonUpdater updater, PersonFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        protected override async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _finder.Find(request.Id);
            if (person == null)
            {
                throw new PersonNotFound();
            }

            await _updater.Update(person, request.FirstName, request.SecondName, request.LastName,
                request.SecondLastName);
        }
    }
}
