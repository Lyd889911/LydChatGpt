using AutoMapper;
using ChatGpt.Domain.Entities.Users.ChatGpt;
using ChatGpt.WebApi.Controllers.Setting.Dtos;

namespace ChatGpt.WebApi.AutoMapperProfiles
{
    public class SettingMapperProfile: Profile
    {
        public SettingMapperProfile()
        {
            CreateMap<ChatGptSetting, SettingDto>()
                .ForMember(dest => dest.Chat, opt =>
                {
                    opt.MapFrom(src => src.Chat);
                });
        }
    }
}
