using PokaList.Domain;
using PokaList.Persistence.Models;
using System.Threading.Tasks;

namespace PokaList.Persistence.Contracts
{
    public interface IPokaPersist
    {
        Task<PageList<Poka>> GetAllPokasAsync(int userId, PageParams pageParams);
        Task<Poka> GetPokaByIdAsync(int userId, int EventoId);
    }
}
