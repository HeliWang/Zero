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
        public IUserService _userServices;

        public UserController(IUserService userServices)
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


        public ActionResult Profile()
        {
            var user = _userServices.GetById(1);
            return View(user);
        }

        [HttpPost]
        public ActionResult Profile(User user)
        {
            ResultInfo resultInfo = new ResultInfo(1, "传递的参数有误");

            if (ModelState.IsValid)
            {
                var oldUser = _userServices.GetById(1);
                oldUser.RealName = user.RealName;
                oldUser.Nick = user.Nick;
                oldUser.QQ = user.QQ;

                resultInfo = _userServices.Edit(oldUser);
            }

            return Json(resultInfo);
        }

        public ActionResult Secure()
        {
            return View();
        }

        public ActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordEdit()
        {
            var oldPassword = RequestHelper.Form("oldPassword");
            var newPassword = RequestHelper.Form("newPassword");
            var confimPassword = RequestHelper.Form("confimPassword");

            ResultInfo resultInfo = new ResultInfo(1, "传递的参数有误");

            if (ModelState.IsValid)
            {
                if (newPassword != confimPassword)
                {
                    resultInfo = new ResultInfo(1, "两次密码输入不正确");
                    return Json(resultInfo); 
                }

                var oldUser = _userServices.GetById(1);

                if (oldUser.Password != oldPassword)
                {
                    resultInfo = new ResultInfo(1, "请输入正确的旧密码");
                    return Json(resultInfo); 
                }

                oldUser.Password = newPassword;
                resultInfo = _userServices.Edit(oldUser);
            }

            return Json(resultInfo);
        }

        public ActionResult Mobile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MobileBind()
        {
            var mobile = RequestHelper.Form("mobile");
            var num = RequestHelper.Form("num");

            ResultInfo resultInfo = _userServices.MobileBind(1, mobile, num);

            return Json(resultInfo);
        }

        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmailBind()
        {
            var email = RequestHelper.Form("email");
            var num = RequestHelper.Form("num");

            ResultInfo resultInfo = _userServices.EmailBind(1, email, num);

            return Json(resultInfo);
        }

        public ActionResult Protection()
        {
            return View();
        }

        public ActionResult Collection()
        {
            return View();
        }

    }
}
