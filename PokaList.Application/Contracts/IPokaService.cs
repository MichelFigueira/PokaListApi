using PokaList.Application.Dtos;
using PokaList.Domain;
using PokaList.Persistence.Models;
using System.Threading.Tasks;

namespace PokaList.Application.Contracts
{
    public interface IPokaService
    {
        Task<PokaDto> AddPoka(int userId, PokaDto model);
        Task<PokaDto> UpdatePoka(int userId, int pokaId, PokaDto model);
        Task<bool> DeletePoka(int userId, int pokaId);

        Task<PageList<PokaDto>> GetAllPokasAsync(int userId, PageParams pageParams);
        Task<PokaDto> GetPokaByIdAsync(int userId, int pokaId);
    }
}
