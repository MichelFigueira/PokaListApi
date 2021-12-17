using PokaList.Domain;
using System.Threading.Tasks;

namespace PokaList.Persistence.Contracts
{
    public interface IPokaPersist
    {
        Task<Poka[]> GetAllPokasAsync();
        Task<Poka> GetPokaByIdAsync(int EventoId);
    }
}
