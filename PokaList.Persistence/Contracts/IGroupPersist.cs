using PokaList.Domain;
using System.Threading.Tasks;

namespace PokaList.Persistence.Contracts
{
    public interface IGroupPersist
    {
        Task<Group[]> GetAllGroupsAsync(int userId);
        Task<Group> GetGroupByIdAsync(int userId, int groupId);
    }
}
