using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero.Domain.Trades;
using Zero.Core.Web;

namespace Zero.Web.Areas.Member.Models
{
    public class OrderModel
    {
        public IPage<Order> OrderPage { get; set; }

        public OrderSearch OrderSearch { get; set; }
    }
}