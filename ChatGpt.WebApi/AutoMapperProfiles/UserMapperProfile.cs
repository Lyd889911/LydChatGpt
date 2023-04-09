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

            CreateMap<User, LoginResponseDto>()
                .ForMember(dest => dest.MaxToken, opt => opt.MapFrom(src => src.ChatGptSetting.Chat.MaxToken))
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.ChatGptSetting.Chat.Temperature))
                .ForMember(dest => dest.AiAvatar, opt => opt.MapFrom(src => src.ChatGptSetting.Avatar))
                .ForMember(dest => dest.ApiAddress, opt => opt.MapFrom(src => src.ChatGptSetting.Chat.ApiAddress))
                .ForMember(dest => dest.EnableContext, opt => opt.MapFrom(src => src.ChatGptSetting.Chat.EnableContext))
                .ForMember(dest => dest.ContextCount, opt => opt.MapFrom(src => src.ChatGptSetting.Chat.ContextCount))
                .ForMember(dest => dest.SystemCospaly, opt => opt.MapFrom(src => src.ChatGptSetting.Chat.SystemCospaly));
        }
    }
}
