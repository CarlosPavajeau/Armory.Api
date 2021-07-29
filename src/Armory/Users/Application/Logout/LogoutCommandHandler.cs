using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using Armory.Users.Domain;

namespace Armory.Users.Application.Logout
{
    public class LogoutCommandHandler : CommandHandler<LogoutCommand>
    {
        private readonly IArmoryUsersRepository _repository;

        public LogoutCommandHandler(IArmoryUsersRepository repository)
        {
            _repository = repository;
        }

        protected override async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _repository.Logout();
        }
    }
}
