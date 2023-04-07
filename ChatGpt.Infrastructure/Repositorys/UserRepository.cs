using ChatGpt.Domain.Entities.Users;
using ChatGpt.Domain.Repositorys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Infrastructure.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly GptDbContext _gptDbContext;
        public UserRepository(GptDbContext _gptDbContext)
        {
            this._gptDbContext = _gptDbContext;
        }
        public async Task AddAsync(User user)
        {
            await _gptDbContext.Users.AddAsync(user);
        }

        public async Task DeleteAsync(Guid userid)
        {
            var user = await _gptDbContext.Users.FindAsync(userid);
            user.Delete();
        }

        public async Task<User?> FindAsync(Guid id)
        {
            return await _gptDbContext.Users.FindAsync(id);
        }

        public Task<User?> FirstAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
