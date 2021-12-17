using PokaList.Domain;
using System.Threading.Tasks;

namespace PokaList.Persistence.Contracts
{
    public interface IPokaPersist
    {
        Task<Poka[]> GetAllPokasAsync();
        Task<Poka> GetPokaByIdAsync(int EventoId);

        Task<Group[]> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(int groupId);
    }
}
