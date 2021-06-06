using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using Armory.Users.Domain;

namespace Armory.Users.Application.GenerateJwt
{
    public class GenerateJwtQueryHandler : IQueryHandler<GenerateJwtQuery, string>
    {
        private readonly IArmoryUserRepository _repository;
        private readonly JwtGenerator _generator;

        public GenerateJwtQueryHandler(IArmoryUserRepository repository, JwtGenerator generator)
        {
            _repository = repository;
            _generator = generator;
        }

        public async Task<string> Handle(GenerateJwtQuery query)
        {
            var user = await _repository.FindByUsernameOrEmail(query.Username);
            if (user == null)
            {
                return string.Empty;
            }

            var token = _generator.Generate(user);
            return token;
        }
    }
}
