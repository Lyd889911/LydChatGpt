using ChatGpt.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Repositorys
{
    public interface IUserRepository
    {
        Task<User> FindByIdAsync(Guid id);
        Task<bool> IsExistByUserName(string username);
        Task<User> LoginAsync(string username, string password);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(Guid userid);
    }
}
