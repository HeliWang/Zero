using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

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
            int pageSize =10 ;
            int pageIndex = RequestHelper.QueryInt("page");
            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;

            OrderModel model = new OrderModel();
            model.OrderSearch = new OrderSearch();
            model.OrderPage= _orderService.GetList(pageIndex,pageSize);

            var orderIds = new List<int>();
            foreach (var order in model.OrderPage.Items)
            {
                orderIds.Add(order.OrderId);
            }
            model.SnapshotList = _orderService.GetSnapshotList(orderIds);
            return View(model);
        }
    }
}
