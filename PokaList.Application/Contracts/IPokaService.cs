using PokaList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokaList.Application.Contracts
{
    public interface IPokaService
    {
        Task<Poka> AddPoka(Poka model);
        Task<Poka> UpdatePoka(int pokaId, Poka model);
        Task<bool> DeletePoka(int pokaId);

        Task<Poka[]> GetAllPokasAsync();
        Task<Poka> GetPokaByIdAsync(int pokaId);
    }
}
