using ChatGpt.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Repositorys
{
    public interface IUserRepository
    {
        Task<User?> FindAsync(Guid id);
        Task<User?> FindByUserNameAsync(string username);
        Task AddAsync(User user);
        Task<List<User>> List(int index, int size);
    }
}
