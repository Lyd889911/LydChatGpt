using Newtonsoft.Json;
using RestSharp;
using System.Text.Json;

namespace ChatGpt.Core
{
    public class GPT
    {
        string token = "";
        string chatUrl = "https://api.openai.com/v1/chat/completions";
        string imageUrl = "https://api.openai.com/v1/images/generations";
        //聊天
        public Task<Stream> Chat(string question)
        {
            List<object> messages = new List<object>();
            messages.Add(new
            {
                role="system",
                content="你有文字洁癖，你很喜欢写markdown格式的文字，任何一段文本你都会写成完美的markdown文本，每一个代码块还会标注该代码的语言。"
            });
            messages.Add(new
            {
                role = "user",
                content = question
            });
            // ChatGpt需要的参数
            var values = new
            {
                model = "gpt-3.5-turbo", // 使用的模型
                temperature = 01,
                max_tokens = 2000,
                stream = true,
                user = "token",
                messages
            };

            var client = new RestClient();
            var request = new RestRequest(chatUrl, Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            string body = JsonConvert.SerializeObject(values);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            return client.DownloadStreamAsync(request);
        }

        public async Task Image(string describe)
        {
            var values = new
            {
                prompt = describe,
                n = 5,
                size = "1024x1024"
            };
            var client = new RestClient();
            var request = new RestRequest(imageUrl, Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("Content-Type", "application/json");
            string body = JsonConvert.SerializeObject(values);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            System.Console.WriteLine(response.Content);
        }
    }
}