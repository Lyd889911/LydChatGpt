using ChatGpt.Domain.Entities.Users.ChatGpt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Repositorys
{
    public interface IChatGptSettingRepository
    {
        Task AddAsync(Guid userid);
        Task UpdateAsync(ChatGptSetting setting);
        Task<ChatGptSetting> FindByUserIdAsync(Guid userid);
    }
}
