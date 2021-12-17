using AutoMapper;
using PokaList.Application.Dtos;
using PokaList.Domain;

namespace PokaList.Application.Helpers
{
    public class PokaListProfile : Profile
    {
        public PokaListProfile()
        {
            CreateMap<Poka, PokaDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
        }
    }
}
