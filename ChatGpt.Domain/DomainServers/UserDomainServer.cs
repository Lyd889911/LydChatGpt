
using ChatGpt.Domain.Entities.Users;
using ChatGpt.Domain.Repositorys;
using ChatGpt.Shared;
using ChatGpt.Shared.Enums;
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
        /// <summary>
        /// 创建用户
        /// </summary>
        public User CreateUser(string userName, string password,string role)
        {
            Role role1 = Enum.Parse<Role>(role);
            int maxUseCountDaily = GetMaxUseCountDaily(role1);
            string avatar = "avatar/a.jpg";
            return new User(userName,password,avatar,maxUseCountDaily,role1);
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
            var user = await _userRepository.FirstAsync(username);
            if (user == null)
                throw new ArgumentNullException("账号密码错误");
            bool b = user.CheckPassword(password);
            if (b)
                return user;
            else
                throw new LoginException("账号密码错误");
        }
        public async Task<User> UpdateUserAsync(Guid id,string username,string password,string? avatar) 
        {
            var user = await _userRepository.FindAsync(id);
            user.SetUserName(username);
            user.SetPassword(password);
            user.SetAvatar(avatar);
            return user;
        }
        /// <summary>
        /// 上传头像
        /// </summary>
        public async Task<Uri?> UploadAsync(Stream stream, string fileName, CancellationToken cancellationToken = default)
        {
            string hash = HashHelper.ComputeSha256Hash(stream);
            long length = stream.Length;
            DateTime today = DateTime.Now;
            //文件的目录,路径
            string path = $"Avatar/{hash}/{fileName}";
            //查找是否存在这个文件,如果存在就不用上传了,直接更改一个修改日期就行了
            if(File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/"+path)))
                return new Uri("http://localhost:5000/" + path);

            //每次都要把指针的位置归零
            stream.Position = 0;
            using FileStream fas = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            stream.CopyTo(fas);
            
            stream.Position = 0;
            return new Uri("http://localhost:5000/" + path);
        }
        private int GetMaxUseCountDaily(Role role)
        {
            switch (role)
            {
                case Role.SuperAdmin: return 2000;
                case Role.Admin:return 1000;
                case Role.SVip:return 100;
                case Role.Vip:return 50;
                    default: return 2;
            }
        }
    }
}
