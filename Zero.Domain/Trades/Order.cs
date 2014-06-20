using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Domain.Trades
{
    public class Order:BaseEntity
    {
        public int OrderId { get; set; }

        public string OrderNo { get; set; }

        public int BuyerId{ get; set; }

        public int SellerId { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity {get;set;}

        public decimal Freight { get; set; }

        public decimal RealPay { get; set; }

        public decimal PayType { get; set; }

        public int Status { get; set; }

        public int RefundStatus { get; set; }

        public DateTime? OrderTime { get; set; }

        public DateTime? PayTime { get; set; }
    }
}
