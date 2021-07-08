using Armory.Shared.Domain.Bus.Query;

namespace Armory.Squads.Application.SearchByCode
{
    public class SearchSquadByCodeQuery : Query
    {
        public string Code { get; }

        public SearchSquadByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
