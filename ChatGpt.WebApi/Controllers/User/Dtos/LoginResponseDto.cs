namespace ChatGpt.WebApi.Controllers.User.Dtos
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public int MaxUseCountDaily { get; set; }
        public int SurplusUserCountDaily { get; set; }
        public string Avatar { get; set; }
        public string AiAvatar { get; set; }
        public string ApiAddress { get; set; }
        public string SystemCospaly { get; set; }
        public int MaxToken { get; set; }
        public decimal Temperature { get; set; }
        public bool EnableContext { get; set; }
        public int ContextCount { get; set; }
        public string Jwt { get; set; }
    }
}
