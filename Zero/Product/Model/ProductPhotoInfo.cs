using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Product.Model
{
    /// <summary>
    /// 根据某个商品属性添加一组图片
    /// </summary>
    public class ProductPhotoInfo
    {
        /// <summary>
        /// 产品图片编号
        /// </summary>
        public int PhotoId { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品属性(kid:vid)
        /// 1:1
        /// </summary>
        public string AttrId { get; set; }

        /// <summary>
        /// 产品属性(kid:vid:key:value；)
        /// 1:1:颜色:黑色
        /// </summary>
        public string Attr { get; set; }

        /// <summary>
        /// 状态（启用，停止）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 组图地址(将上传的图片串成字符串，再解析)
        /// </summary>
        public string Url { get; set; } 

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
