using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Command;

namespace Armory.Users.Application.Create
{
    public class CreateArmoryUserCommandHandler : ICommandHandler<CreateArmoryUserCommand>
    {
        private readonly ArmoryUserCreator _creator;

        public CreateArmoryUserCommandHandler(ArmoryUserCreator creator)
        {
            _creator = creator;
        }

        public async Task Handle(CreateArmoryUserCommand command)
        {
            await _creator.Create(command.UserName, command.Email, command.Phone, command.Password);
        }
    }
}
