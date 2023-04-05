namespace ChatGpt.WebApi.Controllers.User.Dtos
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int MaxCount { get; set; }
    }
}
