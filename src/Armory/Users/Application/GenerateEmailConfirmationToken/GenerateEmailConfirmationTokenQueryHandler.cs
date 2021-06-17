using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Users.Application.GenerateEmailConfirmationToken
{
    public class GenerateEmailConfirmationTokenQueryHandler : IQueryHandler<GenerateEmailConfirmationTokenQuery,
        GenerateConfirmationTokenResponse>
    {
        private readonly EmailConfirmationTokenGenerator _generator;

        public GenerateEmailConfirmationTokenQueryHandler(EmailConfirmationTokenGenerator generator)
        {
            _generator = generator;
        }

        public async Task<GenerateConfirmationTokenResponse> Handle(GenerateEmailConfirmationTokenQuery query)
        {
            return await _generator.GenerateEmailConfirmationToken(query.UsernameOrEmail);
        }
    }
}
