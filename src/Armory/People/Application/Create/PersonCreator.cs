using System.Threading.Tasks;
using Armory.People.Domain;
using Armory.Shared.Domain.Persistence.EntityFramework.Transactions;
using Armory.Users.Application.Create;
using AutoMapper;

namespace Armory.People.Application.Create
{
    public class PersonCreator
    {
        private readonly ITransactionInitializer _initializer;
        private readonly IMapper _mapper;
        private readonly IPeopleRepository _repository;
        private readonly ArmoryUserCreator _userCreator;

        public PersonCreator(IPeopleRepository repository, ArmoryUserCreator userCreator,
            ITransactionInitializer initializer, IMapper mapper)
        {
            _repository = repository;
            _userCreator = userCreator;
            _initializer = initializer;
            _mapper = mapper;
        }

        public async Task Create(CreatePersonCommand command)
        {
            var transaction = await _initializer.Begin();
            var user = await _userCreator.Create(command.Id, command.Email, command.PhoneNumber,
                $"{command.Id.Trim()}{command.FirstName.Trim()}");

            var person = _mapper.Map<Person>(command);
            person.ArmoryUserId = user.Id;

            await _repository.Save(person);

            await transaction.CommitAsync();
        }
    }
}
