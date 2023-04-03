using ChatGpt.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Chats.ChatGpt
{
    public class ChatMessage:AggregateRoot
    {
        public string Message { get;private set; }
        public bool IsBot { get;private set; }
        public string AiChatId { get;private set; }
        public string ApiKey { get;private set; }
        public Guid UserId { get; private set; }
        private ChatMessage()
        {

        }
        public ChatMessage(string message,bool isBot,Guid userId):base(userId)
        {
            this.Message = message;
            this.IsBot = isBot;
            this.UserId = userId;
        }
        public void SetAiChatId(string chatid)
        {
            if(IsBot)
                AiChatId = chatid;
        }
        public void SetApiKey(string apikey)
        {
            if(IsBot)
                ApiKey = apikey;
        }
    }
}
