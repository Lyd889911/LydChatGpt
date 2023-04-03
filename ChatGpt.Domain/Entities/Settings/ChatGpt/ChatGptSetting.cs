using ChatGpt.Shared.Base;
using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Settings.ChatGpt
{

    public class ChatGptSetting:AggregateRoot
    {
        public string ApiKey { get;private set; }
        public Guid AvatarId { get;private set; }
        public Chat Chat { get;private set; }
        public Image Image { get;private set; }
        public Guid UserId { get;private set; }
        private ChatGptSetting()
        {

        }
        public ChatGptSetting(Guid userId, Guid avatarId) :base(userId)
        {
            this.UserId = userId;
            this.AvatarId = avatarId;
            Chat = new(2000, 0.1m);
            Image = new(2, ChatGptImageSize._512);
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
