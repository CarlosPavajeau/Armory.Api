using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.People.Application.Find
{
    public class FindPersonQueryHandler : IQueryHandler<FindPersonQuery, PersonResponse>
    {
        private readonly IMapper _mapper;
        private readonly PersonFinder _searcher;

        public FindPersonQueryHandler(PersonFinder searcher, IMapper mapper)
        {
            _searcher = searcher;
            _mapper = mapper;
        }

        public async Task<PersonResponse> Handle(FindPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _searcher.Find(request.Id);
            return person == null ? null : _mapper.Map<PersonResponse>(person);
        }
    }
}
