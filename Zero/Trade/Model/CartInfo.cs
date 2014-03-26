using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Trade.Model
{
    class CartInfo
    {
        /// <summary>
        /// 购物车编号
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 会员编号
        /// </summary>
        public int BuyerId { get; set; }

        /// <summary>
        /// 游客编号
        /// </summary>
        public string GuestId { get; set; }

        /// <summary>
        /// 订购数量
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 产品列表 
        /// </summary>
        public string ProductList { get; set; }
    }
}
