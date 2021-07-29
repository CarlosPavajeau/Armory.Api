using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.Authenticate
{
    public class AuthenticateCommandHandler : CommandHandler<AuthenticateCommand>
    {
        private readonly ArmoryUserAuthenticator _authenticator;

        public AuthenticateCommandHandler(ArmoryUserAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        protected override async Task Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            await _authenticator.Authenticate(request.UsernameOrEmail, request.Password, request.IsPersistent);
        }
    }
}
