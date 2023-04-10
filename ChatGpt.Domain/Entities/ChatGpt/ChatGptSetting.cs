using ChatGpt.Shared.Base;
using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Users.ChatGpt
{

    public class ChatGptSetting:AggregateRoot
    {
        public string? ApiKey { get;private set; }
        public string? Avatar { get;private set; }
        public Chat Chat { get;private set; }
        public Image Image { get;private set; }
        public Guid UserId { get;private set; }
        private ChatGptSetting()
        {

        }
        public ChatGptSetting(Guid userid)
        {
            this.Id = Guid.NewGuid();
            this.UserId = userid;
            this.Avatar = "avatar/b.jpg";
            Chat = new(2000, 0.1m);
            Image = new(2, ChatGptImageSize._512);
            CreationTime=DateTime.Now;
            ModificationTime=DateTime.Now;
            ModifierId= userid;
            CreatorId= userid;
        }
        
        public void SetApiKey(string apikey)
        {
            ApiKey = apikey;
        }
        public void SetChat(Chat chat)
        {
            Chat = chat;
        }
        public void SetImage(Image image)
        {
            Image = image;
        }

    }
}
