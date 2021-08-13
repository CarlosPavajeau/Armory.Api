using System.Threading.Tasks;

namespace Armory.Shared.Domain.Persistence.EntityFramework
{
    public interface IUnitWork
    {
        Task SaveChanges();
    }
}
