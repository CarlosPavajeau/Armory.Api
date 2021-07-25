using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Armory.Shared.Domain.Persistence.EntityFramework.Transactions
{
    public interface ITransactionInitializer
    {
        Task<IDbContextTransaction> Begin();
    }
}
