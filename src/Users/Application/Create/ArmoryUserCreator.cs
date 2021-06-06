using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Event;
using Armory.Users.Domain;

namespace Armory.Users.Application.Create
{
    public class ArmoryUserCreator
    {
        private readonly IEventBus _eventBus;
        private readonly IArmoryUserRepository _repository;

        public ArmoryUserCreator(IArmoryUserRepository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public async Task Create(string username, string email, string phone, string password)
        {
            var user = ArmoryUser.Create(username, email, phone);

            var result = await _repository.Save(user, password);
            if (!result.Succeeded)
            {
                throw new ArmoryUserNotCreate(result);
            }
        }
    }
}
