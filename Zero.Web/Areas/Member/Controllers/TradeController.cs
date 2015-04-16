using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Web.Areas.Member.Models;
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
            int pageSize =2 ;
            int pageIndex = RequestHelper.QueryInt("page");
            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;

            OrderModel model = new OrderModel();
            model.OrderSearch = new OrderSearch();
            model.OrderPage= _orderService.GetList(pageIndex,pageSize);
            return View(model);
        }
    }
}
