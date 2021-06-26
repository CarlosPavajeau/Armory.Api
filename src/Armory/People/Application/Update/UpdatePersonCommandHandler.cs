using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Update
{
    public class UpdatePersonCommandHandler : ICommandHandler<UpdatePersonCommand>
    {
        private readonly PersonUpdater _updater;

        public UpdatePersonCommandHandler(PersonUpdater updater)
        {
            _updater = updater;
        }

        public async Task Handle(UpdatePersonCommand command)
        {
            await _updater.Update(command.Id, command.FirstName, command.SecondName, command.LastName,
                command.SecondLastName);
        }
    }
}
