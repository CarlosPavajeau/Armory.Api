using System.Threading.Tasks;

namespace Armory.Squadron.Domain
{
    public interface ISquadronRepository
    {
        Task Save(Squadron squadron);
    }
}
