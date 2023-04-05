using ChatGpt.Domain.DomainServers;
using ChatGpt.Domain.Entities.Users;
using ChatGpt.Infrastructure;
using ChatGpt.WebApi.Attributes;
using ChatGpt.WebApi.Controllers.User.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatGpt.WebApi.Controllers.User
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDomainServer _userDomainServer;
        private readonly GptDbContext _gptDbContext;
        public UserController(UserDomainServer userDomainServer, GptDbContext gptDbContext)
        {
            this._userDomainServer = userDomainServer;
            this._gptDbContext = gptDbContext;
        }
        [HttpPost]
        [UnitOfWork(typeof(GptDbContext))]
        public async Task<UserDto> Add(AddUserDto userDto)
        {
            var user = _userDomainServer.CreateUser(userDto.UserName, userDto.Password, new Uri("http://localhost:5166/a.jpeg"));
            user = await _userDomainServer.AddUserAsync(user);
            return new UserDto()
            {
                UserName = user.UserName,
                Avatar = user.Avatar,
                MaxUseCountDaily = user.MaxUseCountDaily,
                SurplusUserCountDaily = user.SurplusUserCountDaily,
                Role = user.Role,
            };
        }
        [HttpPost]
        [UnitOfWork(typeof(GptDbContext))]
        public async Task<UserDto> Update(UpdateUserDto userDto)
        {
            var user = await _userDomainServer.UpdateUserAsync(userDto.Id,userDto.UserName,userDto.Password, new Uri("http://localhost:5166/b.jpeg"));
            return new UserDto()
            {
                UserName = user.UserName,
                Avatar = user.Avatar,
                MaxUseCountDaily = user.MaxUseCountDaily,
                SurplusUserCountDaily = user.SurplusUserCountDaily,
                Role = user.Role,
            };
        }
    }
}
