
using ChatGpt.Domain.Entities.Users;
using ChatGpt.Domain.Repositorys;
using ChatGpt.Shared;
using ChatGpt.Shared.Enums;
using ChatGpt.Shared.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.DomainServers
{
    public class UserDomainServer
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserDomainServer(IUserRepository userRepository, IConfiguration configuration)
        {
            this._userRepository = userRepository;
            this._configuration = configuration;
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        public User CreateUser(string userName, string password,string role,string avatar)
        {
            Role role1 = Enum.Parse<Role>(role);
            if(string.IsNullOrEmpty(avatar))
                avatar = _configuration["DefaultAvatar"];
            return new User(userName,password,avatar,role1);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        public async Task<User> AddUserAsync(User user)
        {
            var existUser = await _userRepository.FindAsync(user.Id);
            if (user.Equals(existUser))
                throw new ExistException("用户名已存在");
            await _userRepository.AddAsync(user);
            return user;
        }
        /// <summary>
        /// 登陆
        /// </summary>
        public async Task<User> LoginAsync(string username,string password)
        {
            var user = await _userRepository.FindByUserNameAsync(username);
            if (user == null)
                throw new ArgumentNullException("账号密码错误");
            bool b = user.CheckPassword(password);
            if (b)
                return user;
            else
                throw new LoginException("账号密码错误");
        }
        /// <summary>
        /// 更新用户
        /// </summary>
        public async Task<User> UpdateUserAsync(Guid id,string username,string password,string role,string? avatar) 
        {
            var user = await _userRepository.FindAsync(id);
            Role role1 = Enum.Parse<Role>(role);
            user.SetUserName(username);
            user.SetPassword(password);
            user.SetAvatar(avatar);
            user.SetRole(role1);
            return user;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid userid)
        {
            var user = await _userRepository.FindAsync(userid);
            user.Delete();
        }
    }
}
