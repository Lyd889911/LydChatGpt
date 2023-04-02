using Microsoft.AspNetCore.Components.Forms;

namespace ChatGpt.Blazor.Server.Pages
{
    public partial class UserSetting
    {
        private string userId;
        private string password;
        private string apiKey;
        private string chatgptSystem;
        private string apiAddress;
        private int maxToken;
        private int temperature;
        private IBrowserFile aiAvatarPath;
        private IBrowserFile yourAvatarPath;
    }
}
