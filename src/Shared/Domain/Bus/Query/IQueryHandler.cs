using System.Threading.Tasks;

namespace Armory.Shared.Domain.Bus.Query
{
    public interface IQueryHandler<in TQuery, TResponse> where TQuery : Query
    {
        Task<TResponse> Handle(TQuery query);
    }
}
