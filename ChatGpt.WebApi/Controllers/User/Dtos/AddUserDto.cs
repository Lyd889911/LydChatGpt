﻿namespace ChatGpt.WebApi.Controllers.User.Dtos
{
    public class AddUserDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
