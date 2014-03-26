using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Product.Enum
{
    public enum ProductType
    {
        /// <summary>
        /// 全新
        /// </summary>
        New = 0,

        /// <summary>
        /// 二手
        /// </summary>
        Old = 1,

        /// <summary>
        /// 拍卖
        /// </summary>
        Auction = 2,
    }

    public enum BaseStatus
    {
        /// <summary>
        /// 回收站
        /// </summary>
        Recycle = -100,

        /// <summary>
        /// 未通过
        /// </summary>
        Failed = -1,

        /// <summary>
        /// 待审核
        /// </summary>
        WaitAudit = 0,

        /// <summary>
        /// 已通过
        /// </summary>
        Pass = 1,

        /// <summary>
        /// 全部
        /// </summary>
        ALL = 99999,
    }
}
