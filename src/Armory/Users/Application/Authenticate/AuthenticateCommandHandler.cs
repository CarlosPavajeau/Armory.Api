using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.Authenticate
{
    public class AuthenticateCommandHandler : ICommandHandler<AuthenticateCommand>
    {
        private readonly ArmoryUserAuthenticator _authenticator;

        public AuthenticateCommandHandler(ArmoryUserAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public async Task Handle(AuthenticateCommand command)
        {
            await _authenticator.Authenticate(command.UsernameOrEmail, command.Password, command.IsPersistent);
        }
    }
}
