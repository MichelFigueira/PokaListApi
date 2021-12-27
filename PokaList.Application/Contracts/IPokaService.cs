using PokaList.Application.Dtos;
using PokaList.Domain;
using System.Threading.Tasks;

namespace PokaList.Application.Contracts
{
    public interface IPokaService
    {
        Task<PokaDto> AddPoka(int userId, PokaDto model);
        Task<PokaDto> UpdatePoka(int userId, int pokaId, PokaDto model);
        Task<bool> DeletePoka(int userId, int pokaId);

        Task<PokaDto[]> GetAllPokasAsync(int userId);
        Task<PokaDto> GetPokaByIdAsync(int userId, int pokaId);
    }
}
