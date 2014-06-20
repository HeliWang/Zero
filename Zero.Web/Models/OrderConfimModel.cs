using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Zero.Domain.Trades;

namespace Zero.Web.Models
{
    public class OrderConfimModel
    {
        public string CartIds { get; set; }

        public List<Cart> CartList { get; set; }
    }
}