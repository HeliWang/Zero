using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Domain.Users;
using Zero.Core.Web;
using Zero.Service.Users;

namespace Zero.Web.Areas.Member.Controllers
{
    public class UserController : Controller
    {
        public IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            ResultInfo resultInfo = new ResultInfo(1, "传递的参数有误");

            if (ModelState.IsValid)
            {
                resultInfo = _userServices.Login(username,password);

                if (resultInfo.Status == 0)
                {
                    //成功后登入并跳转
                    Response.Redirect("/member/user/");
                }
            }

            return View(resultInfo);
        }

        public ActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reg(User user)
        {
            ResultInfo resultInfo = new ResultInfo(1, "传递的参数有误");

            if (ModelState.IsValid)
            {
                resultInfo = _userServices.Register(user);

                //成功后登入并跳转
                Response.Redirect("/member/user/");
            }

            return View(resultInfo);
        }

    }
}
