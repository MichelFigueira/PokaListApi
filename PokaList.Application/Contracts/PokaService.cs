using PokaList.Domain;
using PokaList.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokaList.Application.Contracts
{
    public class PokaService : IPokaService
    {
        private readonly IDefaultPersist _defaultPersist;
        private readonly IPokaPersist _pokaPersist;

        public PokaService(IDefaultPersist defaultPersist, IPokaPersist pokaPersist)
        {
            _defaultPersist = defaultPersist;
            _pokaPersist = pokaPersist;
        }
        public async Task<Poka> AddPoka(Poka model)
        {
            try
            {
                _defaultPersist.Add<Poka>(model);
                if (await _defaultPersist.SaveChangesAsync())
                {
                    return await _pokaPersist.GetPokaByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Poka> UpdatePoka(int pokaId, Poka model)
        {
            try
            {
                var poka = await _pokaPersist.GetPokaByIdAsync(pokaId);
                if (poka == null) return null;

                model.Id = poka.Id;

                _defaultPersist.Update(model);
                if (await _defaultPersist.SaveChangesAsync())
                {
                    return await _pokaPersist.GetPokaByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<bool> DeletePoka(int pokaId)
        {
            throw new NotImplementedException();
        }

        public async Task<Poka[]> GetAllPokasAsync()
        {
            try
            {
                var pokas = await _pokaPersist.GetAllPokasAsync();
                if (pokas == null) return null;

                return pokas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Poka> GetPokaByIdAsync(int pokaId)
        {
            try
            {
                var pokas = await _pokaPersist.GetPokaByIdAsync(pokaId);
                if (pokas == null) return null;

                return pokas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
