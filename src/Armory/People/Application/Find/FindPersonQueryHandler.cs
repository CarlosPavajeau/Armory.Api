using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.Find
{
    public class FindPersonQueryHandler : IQueryHandler<FindPersonQuery, PersonResponse>
    {
        private readonly PersonFinder _searcher;

        public FindPersonQueryHandler(PersonFinder searcher)
        {
            _searcher = searcher;
        }

        public async Task<PersonResponse> Handle(FindPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _searcher.Find(request.Id);
            return person == null ? null : PersonResponse.FromAggregate(person);
        }
    }
}
