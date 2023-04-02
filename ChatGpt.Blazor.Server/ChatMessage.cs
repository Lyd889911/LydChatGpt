namespace ChatGpt.Blazor.Server
{
    public class ChatMessage
    {
        /// <summary>
        /// 聊天的消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 该消息是否是机器人
        /// </summary>
        public bool IsBot { get; set; }
        /// <summary>
        /// 该消息创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 聊天的id
        /// </summary>
        public string ChatId { get; set; }
        /// <summary>
        /// 该消息的用用户id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 该消息使用的apikey
        /// </summary>
        public string ApiKey { get; set; }
    }
}
