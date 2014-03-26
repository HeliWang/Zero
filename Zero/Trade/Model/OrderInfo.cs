using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Trade.Model
{
    class OrderInfo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 店铺编号
        /// </summary>
        public int Shop { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 买家编号
        /// </summary>
        public string BuyerId { get; set; }

        /// <summary>
        /// 卖家编号
        /// </summary>
        public string SellerId { get; set; }

        /// <summary>
        /// 退款编号
        /// </summary>
        public int RefundId { get; set; }

        /// <summary>
        /// 商品折扣，涨价和折扣，会相应的增加或减去设置的金额，增为正数，减为负数。
        /// </summary>
        public decimal DiscountFee { get; set; }

        /// <summary>
        /// 手动调整金额
        /// </summary>
        public decimal AdjustFee { get; set; }

        /// <summary>
        /// 支付的积分数
        /// </summary>
        public decimal Pointfee { get; set; }

        /// <summary>
        /// 总重量
        /// </summary>
        public decimal TotalWeight { get; set; }

        /// <summary>
        /// 总面积
        /// </summary>
        public decimal TotalBulk { get; set; }

        /// <summary>
        /// 总件数
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 总额
        /// </summary>
        public decimal TotalMoney { get; set; }

        /// <summary>
        /// 运费总额
        /// </summary>
        public decimal TotalFreight { get; set; }

        /// <summary>
        /// 总支付金额
        /// </summary>
        public decimal RealPay { get; set; }

        /// <summary>
        /// 获取的积分数
        /// </summary>
        public decimal GetPoint { get; set; }

        /// <summary>
        /// 交易佣金
        /// </summary>
        public decimal CommissionFee { get; set; }

        /// <summary>
        /// 买家留言
        /// </summary>
        public string BuyerMsg { get; set; }

        /// <summary>
        /// 卖家留言
        /// </summary>
        public string SellerMsg { get; set; }

        /// <summary>
        /// 交易来源
        /// WAP(手机);HITAO(嗨淘);TOP(TOP平台);TAOBAO(普通淘宝);JHS(聚划算) 
        /// 一笔订单可能同时有以上多个标记，则以逗号分隔
        /// </summary>
        public string TradeFrom { get; set; }

        /// <summary>
        /// 订单详情
        /// </summary>
        public string OrderDetail { get; set; }

        /// <summary>
        /// 店铺详情
        /// </summary>
        public string ShopDetail { get; set; }

        /// <summary>
        /// 订单状态
        /// TRADE_NO_CREATE_PAY(没有创建支付宝交易)
        /// WAIT_BUYER_PAY(等待买家付款)
        /// WAIT_SELLER_SEND_GOODS(等待卖家发货,即:买家已付款)
        /// WAIT_BUYER_CONFIRM_GOODS(等待买家确认收货,即:卖家已发货)
        /// TRADE_BUYER_SIGNED(买家已签收,货到付款专用)
        /// TRADE_FINISHED(交易成功)
        /// TRADE_CLOSED(付款以后用户退款成功，交易自动关闭)
        /// TRADE_CLOSED_BY_TAOBAO(付款以前，卖家或买家主动关闭交易)
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// 退款状态
        /// WAIT_SELLER_AGREE(买家已经申请退款，等待卖家同意) 
        /// WAIT_BUYER_RETURN_GOODS(卖家已经同意退款，等待买家退货) 
        /// WAIT_SELLER_CONFIRM_GOODS(买家已经退货，等待卖家确认收货) 
        /// SELLER_REFUSE_BUYER(卖家拒绝退款) 
        /// CLOSED(退款关闭) SUCCESS(退款成功)
        /// </summary>
        public string RefundStatus { get; set; }

        /// <summary>
        /// 货到付款状态
        /// 初始状态 NEW_CREATED, 
        /// 接单成功 ACCEPTED_BY_COMPANY, 接单失败 REJECTED_BY_COMPANY,  接单超时 RECIEVE_TIMEOUT, 
        /// 揽收成功 TAKEN_IN_SUCCESS, 揽收失败 TAKEN_IN_FAILED, 揽收超时 RECIEVE_TIMEOUT, 
        /// 签收成功 SIGN_IN, 签收失败 REJECTED_BY_OTHER_SIDE, 
        /// 订单等待发送给物流公司 WAITING_TO_BE_SENT, 用户取消物流订单 CANCELED
        /// </summary>
        public string CodStatus { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 确认时间(3天)
        /// </summary>
        public DateTime AgreeTime { get; set; }

        /// <summary>
        /// 付款时间(3天)
        /// </summary>
        public DateTime PayTime { get; set; }

        /// <summary>
        /// 发货时间(收货时间15天)
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 成功时间
        /// </summary>
        public DateTime SuccessTime { get; set; }

        /// <summary>
        /// 评价时间
        /// </summary>
        public DateTime CommentTime { get; set; }

        /// <summary>
        /// 关闭时间
        /// </summary>
        public DateTime CloseTime { get; set; }
    }
}
