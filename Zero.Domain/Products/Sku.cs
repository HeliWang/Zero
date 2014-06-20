using System;
using System.Collections;
using System.Collections.Generic;

namespace Zero.Domain.Products
{
    /// <summary>
    /// 库存信息
    /// </summary>
    public class Sku : BaseEntity
    {
        /// <summary>
        /// 库存编号
        /// </summary>
        public int SkuId { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品属性(kid:vid:key:value;kid:vid:key:value;....)
        /// 1:1:品牌:盈讯;2:2:型号:F908;自定义属性1:属性值1
        /// </summary>
        public string Attr { get; set; }

        /// <summary>
        /// 产品属性(kid:vid；kid:vid；....)
        /// 1:1;2:2;
        /// </summary>
        public string AttrId { get; set; }

        /// <summary>
        /// 产品属性值(key:value；key:value；....)
        /// 品牌:盈讯;型号:F908;
        /// </summary>
        public string AttrName { get; set; }

        /// <summary>
        /// 自定义图片(一般用于替换颜色)
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// 图片编号
        /// </summary>
        public int PhotoId { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 可购买数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 商家编码
        /// </summary>
        public string OuterId { get; set; }

        /// <summary>
        /// 条形码
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// 正常(1)|删除(0)
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
