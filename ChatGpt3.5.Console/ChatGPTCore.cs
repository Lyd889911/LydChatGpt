using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatGpt3._5.Console
{
    public class ChatGPTCore
    {
        string token = "";
        string chatUrl = "https://api.openai.com/v1/chat/completions";
        string imageUrl = "https://api.openai.com/v1/images/generations";
        //聊天
        public async Task Chat(string question)
        {
            List<object> messages = new List<object>();
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
            //RestResponse response = client.Execute(request);
            using Stream stream = await client.DownloadStreamAsync(request);
            using StreamReader reader = new(stream);
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (line.StartsWith("data:"))
                    line = line.Substring("data:".Length);

                line = line.TrimStart();

                if (line == "[DONE]")
                    break;
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    var res = System.Text.Json.JsonSerializer.Deserialize<GetChatGPTDto>(line, new JsonSerializerOptions()
                    {
                        IgnoreNullValues = true,
                    });
                    System.Console.Write(res?.choices[0].delta?.content);
                }
            }
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
