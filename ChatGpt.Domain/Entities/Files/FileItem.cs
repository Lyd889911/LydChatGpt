using ChatGpt.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Files
{
    public class FileItem:AggregateRoot
    {
        public string? FileName { get; set; }
        public string? Hash { get; set; }
        public long Size { get; set; }
        public FileAddress? Address { get; set; }
        private  FileItem()
        {

        }
        public FileItem(string fileName,string hash,long size,FileAddress address):base(Guid.NewGuid())
        {
            this.FileName = fileName;
            this.Hash = hash;
            this.Size = size;
            this.Address = address;
        }
    }
}
