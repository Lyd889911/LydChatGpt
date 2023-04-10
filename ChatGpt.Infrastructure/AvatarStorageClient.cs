using ChatGpt.Domain;
using ChatGpt.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Infrastructure
{
    public class AvatarStorageClient : IStorageClient
    {
        public string? SaveAsync(string name, Stream stream)
        {
            string hash = HashHelper.ComputeSha256Hash(stream);
            long length = stream.Length;
            DateTime today = DateTime.Now;
            //文件的目录,路径
            string path = $"Avatar/{hash}+{name}";

            if (!Directory.Exists("wwwroot/Avatar"))
                Directory.CreateDirectory("wwwroot/Avatar");

            //查找是否存在这个文件,如果存在就不用上传了,直接更改一个修改日期就行了
            if (File.Exists($"wwwroot/{path}"))
                return path;


            //每次都要把指针的位置归零
            stream.Position = 0;
            using FileStream fas = new FileStream("wwwroot/"+path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            stream.CopyTo(fas);

            stream.Position = 0;
            return path;
        }
    }
}
