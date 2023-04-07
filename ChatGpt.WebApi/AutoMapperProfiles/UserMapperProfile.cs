using AutoMapper;
using ChatGpt.Domain.Entities.Users;
using ChatGpt.WebApi.Controllers.User.Dtos;

namespace ChatGpt.WebApi.AutoMapperProfiles
{
    public class UserMapperProfile:Profile
    {
        public UserMapperProfile()
        {
            CreateMap(typeof(User), typeof(UserDto));
        }
    }
}
