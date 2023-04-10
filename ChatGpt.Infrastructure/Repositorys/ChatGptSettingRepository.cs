using ChatGpt.Domain.Entities.Users.ChatGpt;
using ChatGpt.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Infrastructure.Repositorys
{
    public class ChatGptSettingRepository : IChatGptSettingRepository
    {
        private readonly GptDbContext _dbContext;
        public ChatGptSettingRepository(GptDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task AddAsync(ChatGptSetting setting)
        {
            await _dbContext.ChatGptSettings.AddAsync(setting);
        }

        public Task<ChatGptSetting> FindByUserIdAsync(Guid userid)
        {
            throw new NotImplementedException();
        }
    }
}
