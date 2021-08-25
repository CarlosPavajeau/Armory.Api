using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.People.Application.SearchAllByRole
{
    public class
        SearchAllPeopleByRoleQueryHandler : IQueryHandler<SearchAllPeopleByRoleQuery, IEnumerable<PersonResponse>>
    {
        private readonly IMapper _mapper;
        private readonly PeopleByRoleSearcher _searcher;

        public SearchAllPeopleByRoleQueryHandler(PeopleByRoleSearcher searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonResponse>> Handle(SearchAllPeopleByRoleQuery request,
            CancellationToken cancellationToken)
        {
            var people = await _searcher.SearchAllByRole(request.RoleName);
            return _mapper.Map<IEnumerable<PersonResponse>>(people);
        }
    }
}
