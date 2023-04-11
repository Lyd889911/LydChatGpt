namespace ChatGpt.WebApi.Controllers.Setting.Dtos
{
    public class SettingDto
    {
        public Guid Id { get; set; }
        public string? ApiKey { get; set; }
        public string? Avatar { get; set; }
        public Guid UserId { get; set; }
        public ChatDto Chat { get; set; }
        public ImageDto Image { get; set; }
    }
}
