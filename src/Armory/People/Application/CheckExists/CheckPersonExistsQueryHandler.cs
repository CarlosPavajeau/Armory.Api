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

        public async Task<bool> Handle(CheckPersonExistsQuery query)
        {
            return await _checker.PersonExists(query.Id);
        }
    }
}
