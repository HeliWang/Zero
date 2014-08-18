using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Manage.Models;
using Zero.Core.Web;
using Zero.Domain.Customs;
using Zero.Service.Customs;

namespace Zero.Mvc.Manage.Controllers.Customs
{
    public class CustomController : Controller
    {
        public ICustomService _customService;

        public CustomController(ICustomService customService)
        {
            _customService = customService;
        }

        public ActionResult CustomList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            IPage<Custom> newsItemPage = _customService.GetList(pageIndex, pageSize);

            return Json(newsItemPage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CustomIndex()
        {
            return View();
        }


        public ActionResult CustomAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CustomAdd(CustomModel custom)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            //if (ModelState.IsValid)
            //{
            //    resultInfo = _customService.Add(custom);
            //}

            return Json(resultInfo);
        }

        public ActionResult CustomEdit()
        {
            int customId = RequestHelper.QueryInt("customId");
            Custom custom = _customService.GetById(customId);
            return View(custom);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CustomEdit(Custom custom)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                Custom oldCustomItem = _customService.GetById(custom.CustomId);

                if (oldCustomItem == null)
                {
                    return Json(new ResultInfo(1, "该信息已被删除或不存在，请刷新列表！"));
                }

                oldCustomItem = custom;

                resultInfo = _customService.Edit(custom);
            }

            return Json(resultInfo);
        }

    }
}
