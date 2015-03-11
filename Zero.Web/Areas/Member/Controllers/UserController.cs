using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zero.Web.Areas.Member.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Member/User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Reg()
        {
            return View();
        }

    }
}
