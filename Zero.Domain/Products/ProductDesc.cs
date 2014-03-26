using System;
using System.Collections;
using System.Collections.Generic;

namespace Zero.Domain.Products
{
    /// <summary>
    /// 商品详情
    /// </summary>
    public class ProductDesc
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
