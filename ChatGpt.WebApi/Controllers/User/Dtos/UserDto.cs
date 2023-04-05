using ChatGpt.Domain.Entities.Users.ChatGpt;
using ChatGpt.Shared.Enums;

namespace ChatGpt.WebApi.Controllers.User.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public Uri? Avatar { get; set; }
        public int MaxUseCountDaily { get; set; }
        public int SurplusUserCountDaily { get; set; }
        public UserRole Role { get; set; }
    }
}
