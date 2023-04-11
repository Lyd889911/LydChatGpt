using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatGpt.WebApi.Controllers.Setting
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        [HttpGet("uid")]
        public async Task Get()
        {

        }
    }
}
