using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Users.Application.CheckExists
{
    public class CheckArmoryUserExistsQueryHandler : IQueryHandler<CheckArmoryUserExistsQuery, bool>
    {
        private readonly ArmoryUserExistsChecker _checker;

        public CheckArmoryUserExistsQueryHandler(ArmoryUserExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckArmoryUserExistsQuery request, CancellationToken cancellationToken)
        {
            return await _checker.Exists(request.Email, request.PhoneNumber);
        }
    }
}
