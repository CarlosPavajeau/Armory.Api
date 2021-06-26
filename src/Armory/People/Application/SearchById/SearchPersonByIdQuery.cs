using Armory.Shared.Domain.Bus.Query;

namespace Armory.People.Application.SearchById
{
    public class SearchPersonByIdQuery : Query
    {
        public string Id { get; }

        public SearchPersonByIdQuery(string id)
        {
            Id = id;
        }
    }
}
