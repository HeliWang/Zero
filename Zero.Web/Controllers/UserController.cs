using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Domain.Users;
using Zero.Core.Web;
using Zero.Service.Users;

namespace Zero.Web.Controllers
{
    public class UserController : Controller
    {
        public UserServices _userServices;

        public UserController(UserServices userServices)
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
        public ActionResult Login(string userName, string password, string remember)
        {
            ResultInfo resultInfo = _userServices.Login(userName, password);

            Response.Redirect("/user/");
            
            return View();
        }

        public ActionResult IsExist(string key, string value)
        {
            ResultInfo resultInfo = _userServices.IsExist(key, value);

            return Json(resultInfo);
        }
      
        public ActionResult Register()
        {
           return View();
        }
        
        [HttpPost]
        public ActionResult Register(User user)
        {
            ResultInfo resultInfo = new ResultInfo(1, "传递的参数有误");

            if (ModelState.IsValid)
            {
                resultInfo = _userServices.Register(user);

                //成功后登入并跳转
                Response.Redirect("/member/");
            }

            return View(resultInfo);
        }

        public ActionResult GetPassword()
        {
            return View();
        }
    }
}
