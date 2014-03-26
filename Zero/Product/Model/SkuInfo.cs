using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Product.Model
{
    /// <summary>
    /// 库存信息
    /// </summary>
    public class SkuInfo
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
        /// 产品属性(kid:vid:key:value；kid:vid:key:value；....)
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
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 可购买数量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 已购买数量
        /// </summary>
        public int SaleAmount { get; set; }

        /// <summary>
        /// 正常(1)|删除(0)
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
