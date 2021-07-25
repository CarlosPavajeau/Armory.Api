using System.Threading.Tasks;
using Armory.Shared.Domain.Persistence.EntityFramework.Transactions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Armory.Shared.Infrastructure.Persistence.EntityFramework.Transactions
{
    public class TransactionInitializer : ITransactionInitializer
    {
        private readonly ArmoryDbContext _context;

        public TransactionInitializer(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> Begin()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
