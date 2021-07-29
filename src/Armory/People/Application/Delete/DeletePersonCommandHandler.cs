using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Delete
{
    public class DeletePersonCommandHandler : CommandHandler<DeletePersonCommand>
    {
        private readonly PersonDeleter _deleter;

        public DeletePersonCommandHandler(PersonDeleter deleter)
        {
            _deleter = deleter;
        }

        protected override async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await _deleter.Delete(request.Id);
        }
    }
}
