using ChatGpt.Domain.Entities.Permissions;
using ChatGpt.Domain.Entities.Users.ChatGpt;
using ChatGpt.Shared.Enums;

namespace ChatGpt.WebApi.Controllers.User.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string? Avatar { get; set; }
        public int MaxUseCountDaily { get; set; }
        public int SurplusUserCountDaily { get; set; }
    }
}
