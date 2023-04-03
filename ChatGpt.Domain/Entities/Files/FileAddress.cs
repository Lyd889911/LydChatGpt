using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Files
{
    /// <summary>
    /// 文件地址
    /// </summary>
    public class FileAddress
    {
        /// <summary>
        /// 访问地址
        /// </summary>
        public Uri? Access { get; set; }
        /// <summary>
        /// 备份地址
        /// </summary>
        public Uri? Backup { get; set; }
        internal FileAddress(Uri? access,Uri? backup)
        {
            this.Access = access;
            this.Backup = backup;
        }
    }
}
