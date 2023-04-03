using ChatGpt.Domain.Entities.Users;
using ChatGpt.Domain.Repositorys;
using ChatGpt.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.DomainServers
{
    public class UserDomainServer
    {
        private readonly IUserRepository _userRepository;
        public UserDomainServer(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<User> AddUserAsync(User user)
        {
            var exist = await _userRepository.IsExistByUserName(user.UserName);
            if (exist)
                throw new ExistException("用户名已存在");
            return await _userRepository.AddAsync(user);
        }
    }
}
