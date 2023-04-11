namespace ChatGpt.WebApi.Controllers.Setting.Dtos
{
    public class ChatDto
    {
        public string ApiAddress { get; set; }
        public string SystemCospaly { get; set; }
        public int MaxToken { get; set; }
        public decimal Temperature { get; set; }
        public bool EnableContext { get; set; }
        public int ContextCount { get; set; }
    }
}
