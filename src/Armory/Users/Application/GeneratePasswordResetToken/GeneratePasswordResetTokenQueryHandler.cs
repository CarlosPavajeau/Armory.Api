using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using Armory.Users.Domain;

namespace Armory.Users.Application.GeneratePasswordResetToken
{
    public class GeneratePasswordResetTokenQueryHandler : IQueryHandler<GeneratePasswordResetTokenQuery, PasswordResetTokenResponse>
    {
        private readonly PasswordResetTokenGenerator _generator;

        public GeneratePasswordResetTokenQueryHandler(PasswordResetTokenGenerator generator)
        {
            _generator = generator;
        }

        public async Task<PasswordResetTokenResponse> Handle(GeneratePasswordResetTokenQuery query)
        {
            return await _generator.GeneratePasswordResetToken(query.UsernameOrEmail);
        }
    }
}
