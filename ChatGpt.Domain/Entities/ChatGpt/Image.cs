using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Users.ChatGpt
{

    public class Image
    {
        public int Num { get; set; } 
        public ChatGptImageSize Size { get; set; }
        public Image(int num, ChatGptImageSize size)
        {
            Num = num;
            Size = size;
        }
    }
}
