using System.Threading.Tasks;

namespace Armory.Shared.Domain.Bus.Query
{
    public interface IQueryBus
    {
        Task<TResponse> Ask<TResponse>(Query request);
    }
}
