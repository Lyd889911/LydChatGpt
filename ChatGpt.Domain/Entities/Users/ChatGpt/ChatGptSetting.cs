using ChatGpt.Shared.Base;
using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Users.ChatGpt
{

    public class ChatGptSetting:IHasCreationCreator,IHasModificationCreator
    {
        public Guid Id { get; set; }
        public string? ApiKey { get;private set; }
        public Uri? Avatar { get;private set; }
        public Chat Chat { get;private set; }
        public Image Image { get;private set; }
        public Guid UserId { get;private set; }
        public User User { get;private set; }

        public Guid? CreatorId { get; private set; }

        public DateTime CreationTime { get; private set; }

        public DateTime? ModificationTime { get; private set; }

        public Guid? ModifierId { get; private set; }

        private ChatGptSetting()
        {

        }
        public ChatGptSetting(User user)
        {
            this.Id = Guid.NewGuid();
            this.UserId = user.Id;
            this.User = user;
            this.Avatar = user.Avatar;
            Chat = new(2000, 0.1m);
            Image = new(2, ChatGptImageSize._512);
            CreationTime=DateTime.Now;
            ModificationTime=DateTime.Now;
            ModifierId=user.Id;
            CreatorId=user.Id;
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
