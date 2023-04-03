using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Shared.Base
{
    public interface IHasModificationCreator
    {
        /// <summary>
        /// 最后的更新时间
        /// </summary>
        DateTime? ModificationTime { get; }
        /// <summary>
        /// 最后的更新人
        /// </summary>
        Guid? ModifierId { get;}
    }
}
