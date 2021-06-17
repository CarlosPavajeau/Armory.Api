using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.ChangePassword
{
    public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly PasswordChanger _changer;

        public ChangePasswordCommandHandler(PasswordChanger changer)
        {
            _changer = changer;
        }

        public async Task Handle(ChangePasswordCommand command)
        {
            await _changer.ChangePassword(command.UsernameOrEmail, command.OldPassword, command.NewPassword);
        }
    }
}
