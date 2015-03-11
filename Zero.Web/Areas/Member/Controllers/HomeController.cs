using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Core.Web;

namespace Zero.Web.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Member/Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAuthCode()
        {
            AuthCode authCode = new AuthCode();
            authCode.ImgWidth = 100;
            authCode.ImgHeight = 40;
            byte[] bytes = authCode.CreateAuthCode(5);
            return File(bytes, @"image/jpeg");
        }
    }
}
