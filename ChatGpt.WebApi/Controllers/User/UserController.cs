using AutoMapper;
using ChatGpt.Domain.DomainServers;
using ChatGpt.Domain.Entities.Users;
using ChatGpt.Domain.Repositorys;
using ChatGpt.Infrastructure;
using ChatGpt.Shared.Enums;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly Jwt _jwt;
        public UserController(UserDomainServer userDomainServer, GptDbContext gptDbContext,IMapper mapper, Jwt jwt, IUserRepository userRepository)
        {
            this._userDomainServer = userDomainServer;
            this._gptDbContext = gptDbContext;
            this._mapper = mapper;
            _jwt = jwt;
            this._userRepository = userRepository;
        }
        [HttpPost]
        [UnitOfWork(typeof(GptDbContext))]
        public async Task<UserDto> Add(AddUserDto userDto)
        {
            var user = _userDomainServer.CreateUser(userDto.UserName, userDto.Password,userDto.Role);
            user = await _userDomainServer.AddUserAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        [HttpPost]
        [UnitOfWork(typeof(GptDbContext))]
        public async Task<UserDto> Update(UpdateUserDto userDto)
        {
            var user = await _userDomainServer.UpdateUserAsync(userDto.Id,userDto.UserName,userDto.Password, "avatar/b.jpg");
            return _mapper.Map<UserDto>(user);
        }

        [HttpPost]
        public async Task<LoginResponseDto> Login(LoginRequestDto loginDto)
        {
            var user = await _userDomainServer.LoginAsync(loginDto.UserName,loginDto.Password);
            string jwt = _jwt.Create(user.Id, user.UserName, nameof(user.Role));
            var dto = _mapper.Map<LoginResponseDto>(user);
            dto.Jwt=jwt;
            return dto;
        }

        [HttpGet]
        public async Task<List<UserDto>> List(UserListDto userListDto)
        {
            var list = await _userRepository.List(userListDto.Index, userListDto.Size);
            return _mapper.Map<List<UserDto>>(list);
        }
    }
}
