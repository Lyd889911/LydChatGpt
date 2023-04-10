using ChatGpt.Domain.Entities.Users.ChatGpt;
using ChatGpt.Domain.Repositorys;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.DomainServers
{
    public class SettingDemainServer
    {
        private readonly IChatGptSettingRepository _chatGptSettingRepository;
        private readonly IConfiguration _configuration;
        public SettingDemainServer(IChatGptSettingRepository _chatGptSettingRepository, IConfiguration configuration)
        {
            this._chatGptSettingRepository = _chatGptSettingRepository;
            this._configuration = configuration;
        }
        /// <summary>
        /// 添加默认设置
        /// </summary>
        public async Task<ChatGptSetting> AddSettingAsync(Guid userid)
        {
            string avatar = _configuration["DefaultAiAvatar"];
            ChatGptSetting setting = new ChatGptSetting(userid, avatar);
            await _chatGptSettingRepository.AddAsync(setting);
            return setting;
        }
        /// <summary>
        /// 修改设置
        /// </summary>
        public async Task<ChatGptSetting> UpdateSettingAsync(Guid userid,string? avatar,string apikey,Chat chat,Image image)
        {
            var setting = await _chatGptSettingRepository.FindByUserIdAsync(userid);
            if (setting == null)
                throw new ArgumentNullException("用户没有设置");
            setting.SetAvatar(avatar);
            setting.SetApiKey(apikey);
            setting.SetChat(chat);
            setting.SetImage(image);
            return setting;
        }
    }
}
