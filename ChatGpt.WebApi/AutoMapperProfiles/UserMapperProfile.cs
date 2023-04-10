using AutoMapper;
using ChatGpt.Domain.Entities.Users;
using ChatGpt.WebApi.Controllers.User.Dtos;

namespace ChatGpt.WebApi.AutoMapperProfiles
{
    public class UserMapperProfile:Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserDto>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => nameof(src.Role)));
            CreateMap<User, LoginResponseDto>();
        }
    }
}
