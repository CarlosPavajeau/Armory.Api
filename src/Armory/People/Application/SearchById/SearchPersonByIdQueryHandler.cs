using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchById
{
    public class SearchPersonByIdQueryHandler : IQueryHandler<SearchPersonByIdQuery, PersonResponse>
    {
        private readonly PersonByIdSearcher _searcher;

        public SearchPersonByIdQueryHandler(PersonByIdSearcher searcher)
        {
            _searcher = searcher;
        }

        public async Task<PersonResponse> Handle(SearchPersonByIdQuery query)
        {
            return await _searcher.SearchById(query.Id);
        }
    }
}
