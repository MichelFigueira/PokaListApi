using PokaList.Application.Dtos;
using PokaList.Domain;
using System.Threading.Tasks;

namespace PokaList.Application.Contracts
{
    public interface IPokaService
    {
        Task<PokaDto> AddPoka(PokaDto model);
        Task<PokaDto> UpdatePoka(int pokaId, PokaDto model);
        Task<bool> DeletePoka(int pokaId);

        Task<PokaDto[]> GetAllPokasAsync();
        Task<PokaDto> GetPokaByIdAsync(int pokaId);
    }
}
