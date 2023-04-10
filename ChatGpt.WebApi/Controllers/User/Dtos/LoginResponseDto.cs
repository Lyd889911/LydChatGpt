namespace ChatGpt.WebApi.Controllers.User.Dtos
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public int MaxUseCountDaily { get; set; }
        public int SurplusUserCountDaily { get; set; }
        public string Avatar { get; set; }
        public string Jwt { get; set; }
    }
}
