using System.Threading.Tasks;
using Armory.People.Application.Find;
using Armory.People.Domain;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Update
{
    public class UpdatePersonCommandHandler : ICommandHandler<UpdatePersonCommand>
    {
        private readonly PersonUpdater _updater;
        private readonly PersonFinder _finder;

        public UpdatePersonCommandHandler(PersonUpdater updater, PersonFinder finder)
        {
            _updater = updater;
            _finder = finder;
        }

        public async Task Handle(UpdatePersonCommand command)
        {
            var person = await _finder.Find(command.Id);
            if (person == null)
            {
                throw new PersonNotFound();
            }

            await _updater.Update(person, command.FirstName, command.SecondName, command.LastName,
                command.SecondLastName);
        }
    }
}
