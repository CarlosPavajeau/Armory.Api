using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squadrons.Application.SearchByCode
{
    public class SearchSquadronByCodeQuery : Query
    {
        public string Code { get; }

        public SearchSquadronByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
