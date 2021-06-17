using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;
using Armory.Users.Domain;

namespace Armory.Users.Application.Logout
{
    public class LogoutCommandHandler : ICommandHandler<LogoutCommand>
    {
        private readonly IArmoryUserRepository _repository;

        public LogoutCommandHandler(IArmoryUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(LogoutCommand command)
        {
            await _repository.Logout();
        }
    }
}
