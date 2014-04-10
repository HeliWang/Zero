using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Core.Web;
using Zero.Core.Pattern;
using Zero.Domain.Cates;
using Zero.Service.Cates;

namespace Zero.Mvc.Manage.Controllers.Cates
{
    /// <summary>
    /// 属性管理
    /// </summary>
    public partial class AttrController : BaseController
    {
        AttrService _attrService;

        public AttrController()
        {
            _attrService = Singleton<AttrService>.GetInstance();
        }

        public ActionResult AttrList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            IPage<Attr> productPage = _attrService.GetList(pageIndex, pageSize);

            return Json(productPage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AttrIndex()
        {
            return View();
        }

        public ActionResult AttrAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AttrAdd(Attr attr)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                resultInfo = _attrService.Add(attr);
            }

            return Json(resultInfo);
        }

        public ActionResult AttrEdit()
        {
            int attrId = RequestHelper.QueryInt("attrId");
            Attr attr = _attrService.GetById(attrId);
            return View(attr);
        }

        [HttpPost]
        public ActionResult AttrEdit(Attr attr)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                Attr oldAttr = _attrService.GetById(attr.AttrId);
                oldAttr.AttrName = attr.AttrName;
                oldAttr.Oid = attr.Oid;
                resultInfo = _attrService.Edit(oldAttr);
            }

            return Json(resultInfo);
        }

        [HttpPost]
        public ActionResult AttrOperate()
        {
            ResultInfo resultInfo;

            string action = RequestHelper.All("action").ToLower();
            string ids = RequestHelper.All("ids").ToLower();

            if (action == "" || ids == "")
            {
                resultInfo = new ResultInfo((int)ResultStatus.Error, "未选择任何操作或未选择任何操作项！");
                return Json(resultInfo);
            }

            switch (action)
            {
                case "delete":
                    _attrService.Delete(ids);
                    break;
            }

            return Json(new ResultInfo("操作成功"));
        }
    }
}
