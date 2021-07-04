using System.Threading.Tasks;

namespace Armory.Shared.Domain.Bus.Query
{
    public interface IQueryHandler<in TQuery, TResponse>
    {
        Task<TResponse> Handle(TQuery query);
    }
}
