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

        public async Task<DegreeResponse> Handle(FindDegreeQuery query)
        {
            var degree = await _finder.Find(query.Id);
            return degree == null ? null : DegreeResponse.FromAggregate(degree);
        }
    }
}
