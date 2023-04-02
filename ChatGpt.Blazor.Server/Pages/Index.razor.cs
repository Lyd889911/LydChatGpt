using ChatGpt.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace ChatGpt.Blazor.Server.Pages
{
    public partial class Index
    {
        //是否渲染html代码
        private bool html = false;
        private bool breaks;
        private bool linkify;
        private bool typographer;
        private string message = "";
        [Inject]
        private IJSRuntime jsRuntime { get; set; }
        [Inject]
        private GPT Gpt { get; set; }
        private ElementReference scrollElement;
        private List<ChatMessage> chats = new List<ChatMessage>();
        /// <summary>
        /// 发送消息
        /// </summary>
        private async Task SendMessage()
        {
            ChatMessage cm = new ChatMessage();
            cm.CreationTime = DateTime.Now;
            cm.Message = message;
            cm.IsBot = false;
            chats.Add(cm);
            message = "";
            await GetGptMessage(cm.Message);
            await jsRuntime.InvokeVoidAsync("scrollToEnd2");
        }
        private async Task EnterMeessage()
        {
            await SendMessage();
        }
        private async Task GetGptMessage(string message)
        {
            ChatMessage cm = new ChatMessage();
            cm.CreationTime = DateTime.Now;
            cm.IsBot = true;
            chats.Add(cm);
            using Stream stream = await Gpt.Chat(message);
            //if (stream != null)
            //    return;

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
                    if(cm.ChatId!= res?.id)
                        cm.ChatId=res.id;
                    //System.Console.Write(res?.choices[0].delta?.content);
                    string r = res?.choices[0].delta?.content;
                    cm.Message += r;
                    if(r!=null&&(r.Contains("\r")||r.Contains("\n")))
                        await jsRuntime.InvokeVoidAsync("scrollToEnd2");

                    _ = InvokeAsync(StateHasChanged);
                }
            }
            System.Console.WriteLine(cm.Message);
            //chats[0].Message += "\n";
            //for (int i = 0; i < 100; i++)
            //{
            //    chats[0].Message += i;
            //    await Task.Delay(10);
            //    _ = InvokeAsync(StateHasChanged);
            //}
        }
    }
}
