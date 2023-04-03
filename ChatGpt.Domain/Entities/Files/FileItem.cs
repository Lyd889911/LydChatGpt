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
    }
}
