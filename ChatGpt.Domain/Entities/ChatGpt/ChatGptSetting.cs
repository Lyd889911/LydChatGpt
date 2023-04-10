using ChatGpt.Shared.Base;
using ChatGpt.Shared.Constants;
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
        public ChatGptSetting(Guid userid,string avatar)
        {
            this.Id = Guid.NewGuid();
            this.UserId = userid;
            this.Avatar = avatar;
            Chat = new(2000, 0.1m);
            Image = new(2, ChatGptImageSize._512);
            CreationTime=DateTime.Now;
            ModificationTime=DateTime.Now;
            ModifierId= userid;
            CreatorId= userid;
        }
        
        public void SetApiKey(string apikey)
        {
            if(apikey!=SettingConstant.ApiKeyMask)
                ApiKey = apikey;
        }
        public void SetAvatar(string avatar)
        {
            if(!string.IsNullOrEmpty(avatar)&&avatar!=Avatar)
                Avatar = avatar;
        }
        public void SetChat(Chat chat)
        {
            if(chat!=null)
                Chat = chat;
        }
        public void SetImage(Image image)
        {
            if (image != null)
                Image = image;
        }

    }
}
