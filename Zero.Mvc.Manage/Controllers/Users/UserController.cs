using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Domain.Users;
using Zero.Service.Users;
using Zero.Core.Web;

namespace Zero.Mvc.Manage.Controllers.Users
{
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult UserIndex()
        {
            return View();
        }

        public ActionResult UserList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            IPage<User> newsItemPage = _userService.GetList(pageIndex, pageSize);

            return Json(newsItemPage, JsonRequestBehavior.AllowGet);
        }

    }
}
