using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Shared.Base
{
    public interface IHasCreationCreator
    {
        /// <summary>
        /// 创建者Id
        /// </summary>
        Guid? CreatorId { get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreationTime { get; }
    }
}
