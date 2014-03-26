using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Credit.Model
{
    /// <summary>
    /// 产品评价
    /// </summary>
    public class ProductRateInfo
    {
        /// <summary>
        /// 评价编号
        /// </summary>
        public int RateId { get; set; }

        /// <summary>
        /// 商品快照
        /// </summary>
        public int SnapId { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 评论者编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 评论星级(5星，4星，3星，2星，1星)
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 优点
        /// </summary>
        public string Pros { get; set; }

        /// <summary>
        /// 缺点
        /// </summary>
        public string Cons { get; set; }

        /// <summary>
        /// 总结
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
