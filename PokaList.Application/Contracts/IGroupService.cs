using PokaList.Application.Dtos;
using PokaList.Domain;
using System.Threading.Tasks;

namespace PokaList.Application.Contracts
{
    public interface IGroupService
    {
        Task<GroupDto> AddGroup(int userId, GroupDto model);
        Task<GroupDto> UpdateGroup(int userId, int groupId, GroupDto model);
        Task<bool> DeleteGroup(int userId, int groupId);

        Task<GroupDto[]> GetAllGroupsAsync(int userId);
        Task<GroupDto> GetGroupByIdAsync(int userId, int groupId);
    }
}
