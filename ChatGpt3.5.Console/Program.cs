// See https://aka.ms/new-console-template for more information
using ChatGpt3._5.Console;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using OpenAI_API.Moderation;
using RestSharp;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

Console.WriteLine("Hello, World!");

ChatGPTCore gpt = new ChatGPTCore();
//await gpt.Image("比基尼，大胸，中国美女");
await gpt.Chat("在blazor里面，点击razor组件，我要怎么在C#代码中调用某段js代码呢");
Console.ReadLine();