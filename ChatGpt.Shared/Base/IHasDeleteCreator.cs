using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Shared.Base
{
    public interface IHasDeleteCreator
    {
        /// <summary>
        /// 删除人Id
        /// </summary>
        Guid? DeleteCreatorId { get; }

        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime? DeleteTime { get; }
    }
}
