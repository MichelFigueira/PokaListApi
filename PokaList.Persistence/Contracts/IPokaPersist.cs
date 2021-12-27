using PokaList.Domain;
using System.Threading.Tasks;

namespace PokaList.Persistence.Contracts
{
    public interface IPokaPersist
    {
        Task<Poka[]> GetAllPokasAsync(int userId);
        Task<Poka> GetPokaByIdAsync(int userId, int EventoId);
    }
}
