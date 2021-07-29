using System.Threading;
using System.Threading.Tasks;
using Armory.Shared.Domain.Bus.Query;

namespace Armory.Degrees.Application.Find
{
    public class FindDegreeQueryHandler : IQueryHandler<FindDegreeQuery, DegreeResponse>
    {
        private readonly DegreeFinder _finder;

        public FindDegreeQueryHandler(DegreeFinder finder)
        {
            _finder = finder;
        }

        public async Task<DegreeResponse> Handle(FindDegreeQuery request, CancellationToken cancellationToken)
        {
            var degree = await _finder.Find(request.Id);
            return degree == null ? null : DegreeResponse.FromAggregate(degree);
        }
    }
}
