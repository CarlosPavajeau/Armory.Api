using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using Armory.Users.Domain;

namespace Armory.Users.Application.GenerateJwt
{
    public class GenerateJwtQueryHandler : IQueryHandler<GenerateJwtQuery, string>
    {
        private readonly JwtGenerator _generator;
        private readonly IArmoryUsersRepository _repository;

        public GenerateJwtQueryHandler(IArmoryUsersRepository repository, JwtGenerator generator)
        {
            _repository = repository;
            _generator = generator;
        }

        public async Task<string> Handle(GenerateJwtQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.FindByUsernameOrEmail(request.Username);
            if (user == null)
            {
                return string.Empty;
            }

            var roles = await _repository.SearchAllUserRoles(user);
            var token = _generator.Generate(user, roles);
            return token;
        }
    }
}
