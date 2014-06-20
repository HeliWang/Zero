using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Core.Web;
using Zero.Domain.Trades;
using Zero.Service.Trades;

namespace Zero.Mvc.Manage.Controllers.Trades
{
    public class OrderController : Controller
    {
        public OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        public ActionResult OrderList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            IPage<Order> productPage = _orderService.GetList(pageIndex, pageSize);

            return Json(productPage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SnapshotList()
        {
            //int orderId = RequestHelper.QueryInt("orderId");
            //IPage<Snapshot> snapshotPage = new Page<Snapshot>();
            //snapshotPage.Items = _orderService.GetSnapshotList(orderId);
            //return Json(snapshotPage, JsonRequestBehavior.AllowGet);

            int orderId = RequestHelper.QueryInt("orderId");
            List<Snapshot> snapshotLsit = _orderService.GetSnapshotList(orderId);
            return Json(snapshotLsit, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderIndex()
        {
            return View();
        }

    }
}
