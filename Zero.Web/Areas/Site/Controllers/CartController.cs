using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Core.Web;
using Zero.Domain.Users;
using Zero.Domain.Trades;
using Zero.Service.Trades;

namespace Zero.Web.Areas.Site.Controllers
{
    public class CartController : Controller
    {
        public ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public ActionResult Index()
        {
            User user = new User();
            user.UserId = 1;
            user.GuestId = "";
            List<Cart> cartList = _cartService.GetCartList(user);
            return View(cartList);
        }

        public ActionResult RemoveCart()
        {
            User user = new User();
            user.UserId = 1;
            user.GuestId = "";

            string cartIds = RequestHelper.All("CartIds");
            return Json(_cartService.DeleteCart(user, cartIds));
        }

        public ActionResult SetCartQuantity(Cart cart)
        {
            ResultInfo resultInfo = new ResultInfo(1, "传递的参数有误");

            if (ModelState.IsValid)
            {
                //User user = new User();
                //user.UserId = 1;
                //user.GuestId = "";

                cart.UserId = 1;
                cart.GuestId = "";

                resultInfo = _cartService.SetCartQuantity(cart);
            }

            return Json(resultInfo);
        }

        public ActionResult GetCart()
        {
            User user = new User();
            user.UserId = 1;
            user.GuestId = "";
            List<Cart> cartList = _cartService.GetCartList(user);
            return Json(cartList);
        }
    }
}
