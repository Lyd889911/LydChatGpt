using ChatGpt.Domain.Entities.Settings.ChatGpt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Repositorys
{
    public interface IChatGptSettingRepository
    {
        Task<ChatGptSetting> FindByUserIdAsync(Guid userid);
        Task<ChatGptSetting> UpdateAsync(ChatGptSetting chatGptSetting);
        Task<ChatGptSetting> AddAsync(ChatGptSetting chatGptSetting);

    }
}
