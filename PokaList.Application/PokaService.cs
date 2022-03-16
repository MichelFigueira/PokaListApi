using AutoMapper;
using PokaList.Application.Contracts;
using PokaList.Application.Dtos;
using PokaList.Domain;
using PokaList.Persistence.Contracts;
using PokaList.Persistence.Models;
using System;
using System.Threading.Tasks;

namespace PokaList.Application
{
    public class PokaService : IPokaService
    {
        private readonly IDefaultPersist _defaultPersist;
        private readonly IPokaPersist _pokaPersist;
        private readonly IMapper _mapper;

        public PokaService(IDefaultPersist defaultPersist, IPokaPersist pokaPersist, IMapper mapper)
        {
            _defaultPersist = defaultPersist;
            _pokaPersist = pokaPersist;
            _mapper = mapper;
        }
        public async Task<PokaDto> AddPoka(int userId, PokaDto model)
        {
            try
            {
                var poka = _mapper.Map<Poka>(model);
                poka.UserId = userId;
                poka.TitlePtBr = poka.Title;

                _defaultPersist.Add<Poka>(poka);

                if (await _defaultPersist.SaveChangesAsync())
                {
                    var result = await _pokaPersist.GetPokaByIdAsync(userId, poka.Id);
                    return _mapper.Map<PokaDto>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PokaDto> UpdatePoka(int userId, int pokaId, PokaDto model)
        {
            try
            {
                var poka = await _pokaPersist.GetPokaByIdAsync(userId, pokaId);
                if (poka == null) return null;

                model.Id = poka.Id;
                model.UserId = poka.UserId;

                if (model.TitlePtBr is null) { model.TitlePtBr = poka.Title; }

                _mapper.Map(model, poka);

                _defaultPersist.Update<Poka>(poka);

                if (await _defaultPersist.SaveChangesAsync())
                {
                    var result = await _pokaPersist.GetPokaByIdAsync(userId, poka.Id);
                    return _mapper.Map<PokaDto>(result);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<bool> DeletePoka(int userId, int pokaId)
        {
            throw new NotImplementedException();
        }

        public async Task<PageList<PokaDto>> GetAllPokasAsync(int userId, PageParams pageParams)
        {
            try
            {
                var pokas = await _pokaPersist.GetAllPokasAsync(userId, pageParams);
                if (pokas == null) return null;

                var result = _mapper.Map<PageList<PokaDto>>(pokas);

                result.CurrentPage = pokas.CurrentPage;
                result.TotalPages = pokas.TotalPages;
                result.PageSize = pokas.PageSize;
                result.TotalCount = pokas.TotalCount;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PokaDto> GetPokaByIdAsync(int userId, int pokaId)
        {
            try
            {
                var poka = await _pokaPersist.GetPokaByIdAsync(userId, pokaId);
                if (poka == null) return null;

                var result = _mapper.Map<PokaDto>(poka);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
