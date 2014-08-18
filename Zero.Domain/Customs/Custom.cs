using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.Customs
{
    public class Custom:BaseEntity
    {
        public int id { get { return CustomId; } }

        /// <summary>
        /// 自定义编号
        /// </summary>
        public int CustomId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 条数
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 列表编号
        /// </summary>
        public string Ids { get; set; }

        /// <summary>
        /// 是否缓存
        /// </summary>
        public int IsCache { get; set; }

        /// <summary>
        /// 列表条件
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// 拼接后的sql语句
        /// </summary>
        public string Sql { get; set; }
    }
}
