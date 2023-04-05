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
        public Task<User> AddAsync(User user)
        {
            _gptDbContext.Users.Add(user);
            return Task.FromResult(user);
        }

        public Task DeleteAsync(Guid userid)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FirstAsync(Guid id)
        {
            return _gptDbContext.Users.FirstOrDefaultAsync(x=>x.Id== id);
        }

        public Task<User?> FirstAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
