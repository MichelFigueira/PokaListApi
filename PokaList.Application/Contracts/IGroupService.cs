using PokaList.Application.Dtos;
using PokaList.Domain;
using System.Threading.Tasks;

namespace PokaList.Application.Contracts
{
    public interface IGroupService
    {
        Task<GroupDto> AddGroup(GroupDto model);
        Task<GroupDto> UpdateGroup(int groupId, GroupDto model);
        Task<bool> DeleteGroup(int groupId);

        Task<GroupDto[]> GetAllGroupsAsync();
        Task<GroupDto> GetGroupByIdAsync(int groupId);
    }
}
