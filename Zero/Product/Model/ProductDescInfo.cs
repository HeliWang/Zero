using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Product.Model
{
    /// <summary>
    /// 商品详情
    /// </summary>
    public class ProductDescInfo
    {
        /// <summary>
        /// 商品自增ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }
}
