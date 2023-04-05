
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
        public User CreateUser(string userName, string password, Uri? avatar, int maxUseCountDaily = 20)
        {
            return new User(userName,password,avatar,maxUseCountDaily);
        }
        public async Task<User> AddUserAsync(User user)
        {
            var existUser = await _userRepository.FirstAsync(user.Id);
            if (user.Equals(existUser))
                throw new ExistException("用户名已存在");
            return await _userRepository.AddAsync(user);
        }
        public async Task<User> LoginAsync(string username,string password)
        {
            var user = await _userRepository.FirstAsync(username);
            bool b = user.CheckPassword(password);
            if (b)
                return user;
            else
                throw new LoginException("账号密码错误");
        }
        public async Task<User> UpdateUserAsync(Guid id,string username,string password,Uri? avatar) 
        {
            var user = await _userRepository.FirstAsync(id);
            user.SetUserName(username);
            user.SetPassword(password);
            user.SetAvatar(avatar);
            return user;
        }
    }
}
