using AutoMapper;
using Domain.Dtos.User;
using Domain.Entities;

namespace CrossCutting.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserResultDto>().ReverseMap();
        }
    }
}
