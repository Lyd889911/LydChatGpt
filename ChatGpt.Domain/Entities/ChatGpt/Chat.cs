﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Users.ChatGpt
{
    public class Chat
    {
        public string ApiAddress { get; set; }
        public string SystemCospaly { get; set; }
        public int MaxToken { get; set; }
        public decimal Temperature { get; set; }
        public bool EnableContext { get; set; }
        public int ContextCount { get; set; }

        public Chat(int maxToken, decimal temperature,
            string apiAddress= "https://api.openai.com/v1/chat/completions",
            string systemCospaly="")
        {
            ApiAddress = apiAddress;
            SystemCospaly = systemCospaly;
            MaxToken = maxToken;
            Temperature = temperature;
            EnableContext = false;
            ContextCount = 0;
        }
    }
}
