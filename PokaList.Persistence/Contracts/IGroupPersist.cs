using PokaList.Domain;
using System.Threading.Tasks;

namespace PokaList.Persistence.Contracts
{
    public interface IGroupPersist
    {
        Task<Group[]> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(int groupId);
    }
}
