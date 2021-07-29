using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.CheckExists
{
    public class CheckPersonExistsQueryHandler : IQueryHandler<CheckPersonExistsQuery, bool>
    {
        private readonly PersonExistsChecker _checker;

        public CheckPersonExistsQueryHandler(PersonExistsChecker checker)
        {
            _checker = checker;
        }

        public async Task<bool> Handle(CheckPersonExistsQuery request, CancellationToken cancellationToken)
        {
            return await _checker.Exists(request.Id);
        }
    }
}
