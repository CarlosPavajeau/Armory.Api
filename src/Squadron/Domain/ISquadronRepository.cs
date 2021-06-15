using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armory.Squadron.Domain
{
    public interface ISquadronRepository
    {
        Task Save(Squadron squadron);
        Task<Squadron> Find(string code);
        Task<IEnumerable<Squadron>> GetAll();
    }
}
