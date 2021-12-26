using AutoMapper;
using PokaList.Application.Dtos;
using PokaList.Domain;
using PokaList.Domain.Identity;

namespace PokaList.Application.Helpers
{
    public class PokaListProfile : Profile
    {
        public PokaListProfile()
        {
            CreateMap<Poka, PokaDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
