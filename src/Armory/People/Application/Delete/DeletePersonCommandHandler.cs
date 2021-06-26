using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Delete
{
    public class DeletePersonCommandHandler : ICommandHandler<DeletePersonCommand>
    {
        private readonly PersonDeleter _deleter;

        public DeletePersonCommandHandler(PersonDeleter deleter)
        {
            _deleter = deleter;
        }

        public async Task Handle(DeletePersonCommand command)
        {
            await _deleter.Delete(command.Id);
        }
    }
}
