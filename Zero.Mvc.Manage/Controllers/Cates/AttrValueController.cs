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
    /// 属性值管理
    /// </summary>
    public partial class AttrValueController:BaseController
    {
        IAttrValueService _attrValueService;

        public AttrValueController(IAttrValueService attrValueService)
        {
            _attrValueService = attrValueService;
        }

        public ActionResult AttrValueList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");
            int attrId = RequestHelper.QueryInt("attrId");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            IPage<AttrValue> productPage = _attrValueService.GetList(attrId, pageIndex, pageSize);

            return Json(productPage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AttrValueIndex()
        {
            return View();
        }

        public ActionResult AttrValueAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AttrValueAdd(AttrValue attrValue)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                resultInfo = _attrValueService.Add(attrValue);
            }

            return Json(resultInfo);
        }

        public ActionResult AttrValueEdit()
        {
            int attrId = RequestHelper.QueryInt("attrValueId");
            AttrValue attr = _attrValueService.GetById(attrId);
            return View(attr);
        }

        [HttpPost]
        public ActionResult AttrValueEdit(AttrValue attrValue)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                AttrValue oldAttrValue = _attrValueService.GetById(attrValue.ValueId);
                oldAttrValue.ValueName = attrValue.ValueName;
                oldAttrValue.Oid = attrValue.Oid;
                oldAttrValue.AttrId = attrValue.AttrId;
                resultInfo = _attrValueService.Edit(attrValue);
            }

            return Json(resultInfo);
        }

        [HttpPost]
        public ActionResult AttrValueOperate()
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
                    _attrValueService.Delete(ids);
                    break;
            }

            return Json(new ResultInfo("操作成功"));
        }
    }
}
