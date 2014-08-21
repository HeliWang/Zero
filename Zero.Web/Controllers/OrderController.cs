using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Core.Web;
using Zero.Domain.Users;
using Zero.Domain.Trades;
using Zero.Service.Trades;
using Zero.Web.Models;

namespace Zero.Web.Controllers
{
    public class OrderController : Controller
    {
        public ICartService _cartService;
        public IOrderService _orderService;

        public OrderController(ICartService cartServicem,
            IOrderService orderService)
        {
            _cartService = cartServicem;
            _orderService = orderService;
        }

        [HttpPost]
        public ActionResult Confim()
        {
            User user = new User();
            user.UserId = 1;
            user.GuestId = "";

            OrderConfimModel model = new OrderConfimModel();

            model.CartIds = RequestHelper.All("CartIds");
            model.CartList = _cartService.GetCartList(user.UserId, model.CartIds);

            return View(model);
        }

        [HttpPost]
        public ActionResult ConfimOrder(OrderConfimModel model)
        {
            User user = new User();
            user.UserId = 1;
            user.GuestId = "";

            ResultInfo resultInfo = _orderService.Confirm(user, model.CartIds);

            if (resultInfo.Status == 0)
            {
                Response.Redirect("/Order/Succeed");
            }


            return View(resultInfo);
        }

        public ActionResult Succeed()
        {
            return View();
        }

        public ActionResult Complete()
        {
            return View();
        }
    }
}
