using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Domain.Trades;
using Zero.Service.Trades;
using Zero.Core.Web;

namespace Zero.Web.Areas.Member.Controllers
{
    public class TradeController : Controller
    {
        public IOrderService _orderService;

        public TradeController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public ActionResult Order()
        {
            return View();
        }
    }
}
