using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;
using AutoMapper;

namespace Armory.Degrees.Application.Find
{
    public class FindDegreeQueryHandler : IQueryHandler<FindDegreeQuery, DegreeResponse>
    {
        private readonly DegreeFinder _finder;
        private readonly IMapper _mapper;

        public FindDegreeQueryHandler(DegreeFinder finder, IMapper mapper)
        {
            _finder = finder;
            _mapper = mapper;
        }

        public async Task<DegreeResponse> Handle(FindDegreeQuery request, CancellationToken cancellationToken)
        {
            var degree = await _finder.Find(request.Id);
            return degree == null ? null : _mapper.Map<DegreeResponse>(degree);
        }
    }
}
