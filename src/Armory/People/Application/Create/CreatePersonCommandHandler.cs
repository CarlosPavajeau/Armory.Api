using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.People.Application.Create
{
    public class CreatePersonCommandHandler : CommandHandler<CreatePersonCommand>
    {
        private readonly PersonCreator _creator;

        public CreatePersonCommandHandler(PersonCreator creator)
        {
            _creator = creator;
        }

        protected override async Task Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            await _creator.Create(request.Id, request.FirstName, request.SecondName, request.LastName,
                request.SecondLastName, request.Email, request.PhoneNumber, request.RoleName);
        }
    }
}
