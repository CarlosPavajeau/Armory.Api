using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.People.Application.SearchByArmoryUserId
{
    public class SearchPersonByArmoryUserIdQueryHandler : IQueryHandler<SearchPersonByArmoryUserIdQuery, PersonResponse>
    {
        private readonly IMapper _mapper;
        private readonly PersonByArmoryUserIdSearcher _searcher;

        public SearchPersonByArmoryUserIdQueryHandler(PersonByArmoryUserIdSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<PersonResponse> Handle(SearchPersonByArmoryUserIdQuery request,
            CancellationToken cancellationToken)
        {
            var person = await _searcher.SearchByArmoryUserId(request.ArmoryUserId);
            return _mapper.Map<PersonResponse>(person);
        }
    }
}
