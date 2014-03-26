using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zero.Mvc.Manage.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Index/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Index/
        public ActionResult Main()
        {
            return View();
        }
    }
}
