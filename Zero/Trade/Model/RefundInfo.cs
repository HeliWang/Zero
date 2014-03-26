using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Trade.Model
{
    class RefundInfo
    {
        /// <summary>
        /// 退款编号
        /// </summary>
        public int RefundId { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 存在值为单个商品退款，否则为全部退款
        /// </summary>
        public string SnapId { get; set; }

        /// <summary>
        /// 退款状态
        /// WAIT_SELLER_AGREE(买家已经申请退款，等待卖家同意) 
        /// WAIT_BUYER_RETURN_GOODS(卖家已经同意退款，等待买家退货) 
        /// WAIT_SELLER_CONFIRM_GOODS(买家已经退货，等待卖家确认收货) 
        /// SELLER_REFUSE_BUYER(卖家拒绝退款) 
        /// CLOSED(退款关闭) SUCCESS(退款成功)
        /// </summary>
        public int RefundStatus { get; set; }

        /// <summary>
        /// 货物状态
        /// BUYER_NOT_RECEIVED (买家未收到货) 
        /// BUYER_RECEIVED (买家已收到货) 
        /// BUYER_RETURNED_GOODS (买家已退货)
        /// </summary>
        public int GoodStatus { get; set; }

        /// <summary>
        /// 不需客服介入1; 
        /// 需要客服介入2; 
        /// 客服已经介入3; 
        /// 客服初审完成 4; 
        /// 客服主管复审失败5; 
        /// 客服处理完成6;
        /// </summary>
        public string CsStatus { get; set; }

        /// <summary>
        /// 是否需要退货
        /// </summary>
        public bool HasGood { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal RefundFee { get; set; }

        /// <summary>
        /// 退款原因
        /// </summary>
        public int Reason { get; set; }

        /// <summary>
        /// 退款说明
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
